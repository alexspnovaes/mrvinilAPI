using FluentValidator.Validation;
using Shared.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class OrderCashBackItem : Entity
    {
        private OrderCashBackItem() { }
        public OrderCashBackItem(OrderItem orderItem, decimal perCachBack)
        {
            OrderItem = orderItem;
            PerCachBack = perCachBack;
            ValueCachBack = ((orderItem.UnitPrice * orderItem.Quantity) * perCachBack) / 100;

            AddNotifications(orderItem.Notifications);
        }

        public OrderItem OrderItem { get; private set; }
        public decimal ValueCachBack { get; private set; }
        public decimal PerCachBack { get; private set; }
        
    }
}
