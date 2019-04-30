using Domain.Command.Handlers;
using Domain.Command.Inputs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;

namespace API.Controllers
{

    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderCashBackRepository _orderCashBackRepository;
        private readonly OrderHandler _handler;
        public OrderController(
            IOrderRepository orderRepository,
            IOrderCashBackRepository orderCashBackRepository, 
            OrderHandler handler)
        {
            _orderRepository = orderRepository;
            _orderCashBackRepository = orderCashBackRepository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/orders/client/{id}")]
        [AllowAnonymous]
        public ActionResult<List<Order>> GetByClientId(Guid id)
        {
            return Ok(_orderCashBackRepository.GetByClientId(id));
        }

        [HttpGet]
        [Route("v1/orders/{id}")]
        public ActionResult<Order> Get(Guid id)
        {
            return Ok(_orderRepository.GetById(id));
        }

        [Route("v1/orders/paged")]
        [HttpGet()]
        public ActionResult<PaginatedResult<Order>> GetPaged(DateTime startDate, DateTime endDate, int actualPage = 1, int pageSize = 10)
        {
            return Ok(_orderRepository.GetPagedResult(startDate, endDate, actualPage, pageSize));
        }




        [HttpPost]
        [AllowAnonymous]
        [Route("v1/orders/newOrder")]
        public IActionResult NewOrder([FromBody]NewBasket command)
        {
            var result = _handler.Handle(command);
            if (_handler.Valid)
            {
                return Ok(new { sucess = true, data = result });
            }
            else
            {
                return BadRequest(new
                {
                    sucesso = false,
                    erros = _handler.Notifications
                });
            }
        }

    }
}