using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        PaginatedResult<Client> GetPagedResult(int actualPage, int pageSize);
        bool UserExists(string ClientUniqueId);
        Client GetByUsername(string username);
    }
}
