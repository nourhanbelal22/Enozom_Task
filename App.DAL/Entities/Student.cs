using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int phoneNumber { get; set; }
        public string Email { get; set; }
        public List<StudentBookCopy> BookCopies { get; set; }
    }
}
