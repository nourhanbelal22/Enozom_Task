using LibraryBL.Dtos;
using LibraryBL.IServices;
using LibraryDAL.Entities;
using LibraryDAL.Interfaces;
using LibraryDAL.Reposatiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.Services
{
    public class BookServices :IBookService
    {

        private readonly IBookReository _bookCopyRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<StudentBookCopy> _borrowRecordRepository;

        public BookServices(IBookReository bookCopyRepository, 
            IRepository<Student> studentRepository,
            IRepository<StudentBookCopy> borrowRecordRepository)
        {
            _bookCopyRepository = bookCopyRepository;
            _studentRepository = studentRepository;
            _borrowRecordRepository = borrowRecordRepository;
        }

        public async Task BorrowBookAsync(int bookCopyId, int studentId, DateTime ExpectedReturnDate)
        {
            var bookCopy = await _bookCopyRepository.GetByIdAsync(bookCopyId);
            if (bookCopy == null || !string.Equals(bookCopy.status, "Good", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Book copy is not available for borrowing.");
            }

            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            var borrowRecord = new StudentBookCopy
            {
                CopyId = bookCopyId,
                StudentId = studentId,
                borrowedDate = DateTime.Now,
                expectedReturnDate = ExpectedReturnDate
            };

            //To sure 2 operation successfull if on failed through ex
            try
            {
                await _borrowRecordRepository.AddAsync(borrowRecord); 
                bookCopy.status = "Borrowed";
                await _bookCopyRepository.UpdateAsync(bookCopy); 

            }
            catch (Exception ex)
            {
               
                throw new Exception("Failed to borrow book.", ex);
            }
        }

        public async Task ReturnBookAsync(int bookCopyId, string returnStatus)
        {
            var bookCopy = await _bookCopyRepository.GetByIdAsync(bookCopyId);
            if (bookCopy == null || bookCopy.status != "Borrowed")
            {
                throw new Exception("Book not borrowed for now");
            }
            var borrowRecord = await _borrowRecordRepository.FindAsync(br => br.CopyId == bookCopyId && br.actualReturnDate == null);
            var currentBorrowRecord = borrowRecord.FirstOrDefault();
            if (currentBorrowRecord == null)
            {
                throw new Exception("No match borrow record found.");
            }
            currentBorrowRecord.actualReturnDate = DateTime.Now;
            currentBorrowRecord.ReturnStatus = returnStatus;
            bookCopy.status = returnStatus;

            try
            {
                await _borrowRecordRepository.UpdateAsync(currentBorrowRecord);
                await _bookCopyRepository.UpdateAsync(bookCopy);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to return book.", ex);
            }
        }

        public async Task<IEnumerable<BookCopyDto>> GetBookCurrentStatus()
        {
            var bookCopies = await _bookCopyRepository.GetBookCurrentStatus();

            return bookCopies.Select(bc => new BookCopyDto
            {
                CopyId = bc.Id,
                Status = bc.status,
                BookTitle = bc.book.Title
            }).ToList();
        }
    }
}
