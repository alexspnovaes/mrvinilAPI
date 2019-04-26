using System;
using System.Collections.Generic;
using Domain.Command.Results;
using Domain.Entities;
using Shared;

namespace Domain.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        PaginatedResult<Order> GetPagedResult(DateTime startDate, DateTime endDate, int actualPage, int pageSize);
        void AddAndSave(Order order, OrderCashBack orderCashBack);
    }
}
