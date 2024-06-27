using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int copyId { get; set; }
        public List<BookCopy> BookCopies { get; set; }= new List<BookCopy>();
    }
}
