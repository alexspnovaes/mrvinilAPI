using FluentValidator.Validation;
using Shared.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class OrderCashBack : Entity
    {
        protected OrderCashBack() { }
        public OrderCashBack(Order order)
        {
            Order = order;
        }

        public Order Order { get; private set; }
        public decimal OrderCashbackValue { get; private set; }

        public List<OrderCashBackItem> OrderCashbacktems { get; set; } = new List<OrderCashBackItem>();

        public void AddCashbackOrderItem(OrderCashBackItem item)
        {
            OrderCashbackValue += item.ValueCachBack;
            OrderCashbacktems.Add(item);
        }
    }
}
