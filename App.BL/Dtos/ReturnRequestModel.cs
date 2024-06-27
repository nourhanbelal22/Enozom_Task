using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBL.Dtos
{
    public class ReturnRequestModel
    {
        public int BookCopyId { get; set; }
        public string ReturnStatus { get; set; }
    }
}
