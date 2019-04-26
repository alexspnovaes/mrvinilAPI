using Domain.Entities;
using Shared.Command;

namespace Domain.Command
{
    public class NewClient : IMrVinilCommand
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Clienteuniqueid { get; set; }
    }
}
