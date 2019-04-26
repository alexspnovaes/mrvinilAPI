using Shared.Command;
using System;

namespace Domain.Command
{
    public class NewOrderItem 
    {
        public NewOrderItem(Guid diskId, decimal unitPrice, int quantity)
        {
            DiskId = diskId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        public Guid DiskId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
