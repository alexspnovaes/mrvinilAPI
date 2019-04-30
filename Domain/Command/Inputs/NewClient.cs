using Domain.Entities.Validators;
using Domain.Interfaces;
using Shared.Command;
using Shared.Command.Interfaces;

namespace Domain.Command.Inputs
{
    public class NewClient : CommandAbstract, IMrVinilCommand
    {
        public bool IsValid(IClientRepository clientRepository)
        {
            ValidationResult = new ClientValidator(clientRepository).Validate(this);
            return ValidationResult.IsValid;
        }


        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Clienteuniqueid { get; set; }
    }
}
