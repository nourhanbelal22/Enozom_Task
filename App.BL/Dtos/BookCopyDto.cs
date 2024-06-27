using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.Dtos
{
    public class BookCopyDto
    {
        public string BookTitle { get; set; }
        public int CopyId { get; set; }
        public string Status { get; set; }
       
    }
}
