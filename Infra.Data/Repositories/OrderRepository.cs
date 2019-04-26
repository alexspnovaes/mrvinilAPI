using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Data.Context;
using Shared;
using System.Linq;
using Domain.Command.Results;

namespace Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MrVinilContext _context;
        public OrderRepository(MrVinilContext context)
        {
            _context = context;
        }
        public void AddAndSave(Order order, OrderCashBack orderCashBack)
        {
            _context.OrderCashBacks.Add(orderCashBack);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Add(Order obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(Guid id)
        {
            return _context.Orders
                .Include("Client")
                .Include("orderItems")
                .Include("orderItems.disk")
                .FirstOrDefault(w => w.Id == id);
        }

        public PaginatedResult<Order> GetPagedResult(DateTime startDate, DateTime endDate, int actualPage, int pageSize)
        {
            return new PaginatedResult<Order>(_context.Orders
                .Include("Client")
                .Include("orderItems")
                .Include("orderItems.disk")
                .Where(w => w.Date >= startDate && w.Date <= endDate)
                .OrderByDescending(o => o.Date), actualPage, pageSize);
        }

        public void Remove(Order obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
