using Shared.Command;

namespace Domain.Command
{ 
    public class AuthenticateUserCommand : IMrVinilCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
