using Domain.Entities;
using Shared.Command;

namespace Domain.Command
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
