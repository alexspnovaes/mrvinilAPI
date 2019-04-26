using Shared.Command;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Domain.Command
{
    public class NewBasket : IMrVinilCommand
    {
        public NewBasket(Guid clientId, IEnumerable<NewOrderItem> items)
        {
            ClientId = clientId;
            Items = items;
        }

        public Guid ClientId { get; private set; }
        public IEnumerable<NewOrderItem> Items { get; set; }
    }
}
