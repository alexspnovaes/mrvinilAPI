using Shared.Command.Interfaces;

namespace Domain.Command.Inputs
{ 
    public class AuthenticateUserCommand : IMrVinilCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
