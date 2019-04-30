using Domain.Entities;
using Shared.Command;
using Shared.Command.Interfaces;

namespace Domain.Command.Inputs
{
    public class NewOrder : IMrVinilCommand
    {
        public NewOrder(Order order)
        {
            Order = order;
        }
        public Order  Order { get; private set; }
    }
}
