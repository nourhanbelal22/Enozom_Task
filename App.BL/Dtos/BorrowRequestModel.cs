using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.Dtos
{
    public class BorrowRequestModel
    {
        public int BookCopyId { get; set; }
        public int StudentId { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}
