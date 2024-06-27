using LibraryDAL.Data;
using LibraryDAL.Entities;
using LibraryDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Reposatiories
{
    public class BookCopyRepository: BaseRepository<BookCopy> , IBookReository
    {
       
        public BookCopyRepository(LibraryDbContext context):base(context) { }

        public async Task<IEnumerable<BookCopy>> GetBookCurrentStatus()
        {
            return await _context.BookCopies.Include(b=>b.book).ToListAsync();
        }
    }
}
