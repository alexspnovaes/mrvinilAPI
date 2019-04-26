using Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command.Results
{
    public class ClientResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClientUniqueId { get; set; }
    }
}
