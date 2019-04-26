using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDiskRepository : IBaseRepository<Disk>
    {
        PaginatedResult<Disk> GetPagedResult(int genre, int actualPage, int pageSize);
        IEnumerable<Disk> GetByGenre(int genre);
    }
}
