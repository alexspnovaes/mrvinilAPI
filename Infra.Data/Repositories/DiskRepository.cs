using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Data.Context;
using Shared;
using System.Linq;
using Domain.Enumerators;

namespace Data.Repositories
{
    public class DiskRepository : IDiskRepository
    {
        private readonly MrVinilContext _context;

        public DiskRepository(MrVinilContext context)
        {
            _context = context;
        }
        public void Add(Disk obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Disk> GetAll()
        {
            return _context.Disks;
        }

        public IEnumerable<Disk> GetByGenre(int genre)
        {
            return _context.Disks.Where(w => w.Genre == (EDiskGenre)genre);
        }

        public Disk GetById(Guid id)
        {
            return _context.Disks.FirstOrDefault(x => x.Id == id);
        }

        public PaginatedResult<Disk> GetPagedResult(int genre, int actualPage, int pageSize)
        {
            return new PaginatedResult<Disk>(_context.Disks.Where(w=>w.Genre == (EDiskGenre)genre).OrderBy(x => x.Name), actualPage, pageSize);
        }

        public void Remove(Disk obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Disk obj)
        {
            throw new NotImplementedException();
        }
    }
}
