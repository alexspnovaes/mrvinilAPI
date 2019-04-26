using FluentValidator.Validation;
using Shared.Entities;
using System;

namespace Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem() { }
        public OrderItem(Disk disk, decimal unitPrice, int quantity)
        {
            Disk = disk;
            UnitPrice = unitPrice;
            Quantity = quantity;

            AddNotifications(disk.Notifications);

            new ValidationContract()
                                   .IsGreaterThan(UnitPrice, 0, "UnitPrice", "Preço deve ser maior que zero")
                                   .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade deve ser maior que zero");
        }

        public Disk Disk { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
    }
}
