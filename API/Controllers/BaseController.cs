using FluentValidator;
using Data.Transaction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Shared.Notifications;

namespace API.Controllers
{
    public class BaseController : Controller
    {

        private readonly IUnitOfWork _uow;

        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, ValidationResult notificacaoes)
        {
            if (notificacaoes.IsValid)
            {
                try
                {
                    _uow.Commit();
                    return Ok(new { sucesso = true, data = result });
                }
                catch (Exception ex)
                {
                    //logar com elmah
                    return BadRequest(new { sucesso = false, erros = new[] { "Ocorreu uma falha interna no servidor" } });
                }
            }
            else
            {
                return BadRequest(new { sucesso = false, erros = notificacaoes });
            }
        }
    }
}