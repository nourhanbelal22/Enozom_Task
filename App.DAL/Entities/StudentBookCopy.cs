using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Entities
{
    public class StudentBookCopy
    {
        public int Id { get; set; }
        public string ?ReturnStatus { get; set; }
        public int CopyId { get; set; }
        public int StudentId { get; set; }
        public BookCopy bookCopy { get; set; }
        public Student student { get; set; }
        public DateTime? borrowedDate { get; set; }
        public DateTime? expectedReturnDate { get; set; }
        public DateTime? actualReturnDate { get; set; }
    }
}
