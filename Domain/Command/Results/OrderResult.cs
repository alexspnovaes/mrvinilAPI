using Shared.Command;

namespace Domain.Command.Results
{
    public class OrderResult : ICommandResult
    {
        public OrderResult(string number) 
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
