using System.Threading.Tasks;
using Data.Transaction;
using Domain.Command.Handlers;
using Domain.Command.Inputs;
using Domain.Entities.Validators;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Notifications;

namespace API.Controllers
{
    public class ClientController : BaseController
    {
        private readonly ClientHandler _handler;
        private readonly IClientRepository _clientRepository;
        private readonly NewClient _newClient;
        public ClientController(IUnitOfWork uow, 
            ClientHandler handler, 
            IClientRepository clientRepository,
            NewClient newClient)
            : base(uow)
        {
            _handler = handler;
            _clientRepository = clientRepository;
            _newClient = newClient;
        }

        [HttpPost]
        [Route("v1/customers")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]NewClient command)
        {
            var result = _handler.Handle(command);            
            return await Response(result, command.ValidationResult);
        }
    }
}