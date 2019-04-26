using FluentValidator.Validation;
using Shared.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    
    public class Order : Entity
    {
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        protected Order() { }
        public Order(Client client)
        {
            Client = client;
            _orderItems = new List<OrderItem>();
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            AddNotifications(client.Notifications);
        }
        public Client Client { get; private set; }
        public DateTime Date { get; private set; }
        public string Number { get; private set; }


        public ICollection<OrderItem> OrderItems => _orderItems;

        public void AddOrderItem(OrderItem item)
        {
            _orderItems.Add(item);
        }
    }
}
