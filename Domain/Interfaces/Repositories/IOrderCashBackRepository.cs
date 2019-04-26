using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IOrderCashBackRepository : IBaseRepository<OrderCashBack>
    {
        List<OrderCashBack> GetByClientId(Guid id);
    }
}
