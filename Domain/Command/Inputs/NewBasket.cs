using Shared.Command;
using Shared.Command.Interfaces;
using System;
using System.Collections.Generic;
namespace Domain.Command.Inputs
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
