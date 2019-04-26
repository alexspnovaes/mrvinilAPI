using System.Threading.Tasks;
using Data.Transaction;
using Domain.Command;
using Domain.Command.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientController : BaseController
    {
        private readonly ClientHandler _handler;

        public ClientController(IUnitOfWork uow, ClientHandler handler) 
            :base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/customers")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]NewClient command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}