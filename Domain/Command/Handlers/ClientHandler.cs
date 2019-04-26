using Domain.Interfaces;
using Shared.Command;
using System;
using System.Collections.Generic;
using FluentValidator;
using Domain.Command.Results;
using Domain.Entities;

namespace Domain.Command.Handlers
{
    public class ClientHandler : Notifiable, ICommandHandler<NewClient>
    {
        //injection
        private readonly IClientRepository _clientRepository;

        public ClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ICommandResult Handle(NewClient command)
        {
            var client = new Client(command.Name, command.UserName, command.Email, command.Password, command.Clienteuniqueid);

            if (_clientRepository.UserExists(client.ClientUniqueId))
            {
                AddNotification("Cliente", "Cliente já cadastrado");
                return null;
            }

            AddNotifications(client.Notifications);

            if (Valid)
            {
                _clientRepository.Add(client);
                return new ClientResult
                {
                    Id = client.Id,
                    Name = client.Name,
                    ClientUniqueId = client.ClientUniqueId
                };
            }
            else
            {
                return null;
            }

        }
    }
}
