using Domain.Interfaces;
using Domain.Command.Results;
using Domain.Entities;
using Shared.Command.Interfaces;
using Domain.Command.Inputs;
using System.Linq;
using Shared.Notifications;
using Shared.Command;
using FluentValidation.Results;

namespace Domain.Command.Handlers
{
    public class ClientHandler : ICommandHandler<NewClient>
    {
        //injection
        private readonly IClientRepository _clientRepository;
        private readonly DomainNotificationHandler _domainNotificationHandler;

        public ClientHandler(IClientRepository clientRepository, DomainNotificationHandler domainNotificationHandler)
        {
            _clientRepository = clientRepository;
            _domainNotificationHandler = domainNotificationHandler;
        }

        public ICommandResult Handle(NewClient command)
        {
            if (!command.IsValid(_clientRepository))
            {
                command.ValidationResult.Errors.ToList().ForEach(error => _domainNotificationHandler.Handle(new DomainNotification(command.GetType().ToString(), error.ErrorMessage)));
                return null;
            }

            var client = new Client(command.Name, command.UserName, command.Email, command.Password, command.Clienteuniqueid);

            _clientRepository.Add(client);
            return new ClientResult
            {
                Id = client.Id,
                Name = client.Name,
                ClientUniqueId = client.ClientUniqueId
            };
        }
    }
}
