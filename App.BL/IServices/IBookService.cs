using LibraryBL.Dtos;
using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.IServices
{
    public interface IBookService
    {
        Task BorrowBookAsync(int bookCopyId, int studentId, DateTime expectedReturnDate);
        Task ReturnBookAsync(int bookCopyId, string status);
        Task<IEnumerable<BookCopyDto>> GetBookCurrentStatus();
    }
}
