using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Data.Context;
using System.Linq;

namespace Data.Repositories
{
    public class OrderCashBackRepository : IOrderCashBackRepository
    {
        private readonly MrVinilContext _context;
        public OrderCashBackRepository(MrVinilContext context)
        {
            _context = context;
        }
        public void Add(OrderCashBack orderCashBack)
        {
            _context.OrderCashBacks.Add(orderCashBack);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderCashBack> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderCashBack GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<OrderCashBack> GetByClientId(Guid id)
        {
            return new List<OrderCashBack>(_context.OrderCashBacks
               .Include("orderCashbacktems")
               .Include("order")
               .Include("order.orderitems")
               .Include("order.orderitems.disk")
               .Where(w => w.Order.Client.Id == id)
               .OrderByDescending(o => o.Order.Date));
        }

        public void Remove(OrderCashBack obj)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderCashBack obj)
        {
            throw new NotImplementedException();
        }
    }
}
