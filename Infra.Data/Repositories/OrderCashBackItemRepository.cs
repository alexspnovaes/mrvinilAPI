using Domain.Entities;
using Domain.Interfaces;
using Data.Context;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class OrderCashBackItemRepository : IOrderCashBackItemRepository
    {
        private readonly MrVinilContext _context;
        public OrderCashBackItemRepository(MrVinilContext context)
        {
            _context = context;
        }
        public void Add(OrderCashBackItem obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderCashBackItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderCashBackItem GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderCashBackItem obj)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderCashBackItem obj)
        {
            throw new NotImplementedException();
        }
    }
}