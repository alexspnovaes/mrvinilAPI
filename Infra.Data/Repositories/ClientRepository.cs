using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using Data.Context;
using Shared;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MrVinilContext _context;

        public ClientRepository(MrVinilContext context)
        {
            _context = context;
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.AsNoTracking().ToList();
        }

        public Client GetById(Guid id)
        {
            return _context.Clients.FirstOrDefault(x => x.Id == id);
        }

        public Client GetByUsername(string username)
        {
            return _context.Clients.FirstOrDefault(x => x.UserName == username);
        }

        public PaginatedResult<Client> GetPagedResult(int actualPage, int pageSize)
        {
            return new PaginatedResult<Client>(_context.Clients.OrderBy(x => x.Name), actualPage, pageSize);
        }

        public void Remove(Client obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Client obj)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string ClientUniqueId)
        {
            return _context.Clients.AsNoTracking().Any(x => x.ClientUniqueId == ClientUniqueId);
        }
    }
}
