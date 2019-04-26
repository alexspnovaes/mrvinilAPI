using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Data.Context;

namespace Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly MrVinilContext _context;
        public OrderItemRepository(MrVinilContext context)
        {
            _context = context;
        }
        public void Add(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderItem GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderItem obj)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem obj)
        {
            throw new NotImplementedException();
        }
    }
}
