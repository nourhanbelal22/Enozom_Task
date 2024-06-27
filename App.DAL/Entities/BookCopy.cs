﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Entities
{
    public class BookCopy
    {
        public int Id { get; set; }
        public string status { get; set; }
        public int BookId { get; set; }
        public Book book { get; set; }
        public List<StudentBookCopy> studentBookCopies { get; set; }


    }
}
