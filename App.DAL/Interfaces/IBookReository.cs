using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Interfaces
{
    public interface IBookReository:IRepository<BookCopy>
    {
        Task<IEnumerable<BookCopy>> GetBookCurrentStatus();
    }
}
