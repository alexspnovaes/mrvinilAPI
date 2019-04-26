using Domain.Command.Results;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using FluentValidator;
using Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Domain.Command.Handlers
{
    public class OrderCashBackHandler : Notifiable
    {
        //injection
        //injection
        private readonly IOrderCashBackRepository _orderCashBackRepository;
        private readonly ICashBackService _cashBackService;
        public OrderCashBackHandler(IOrderCashBackRepository orderRepository, ICashBackService cashBackService)
        {
            _orderCashBackRepository = orderRepository;
            _cashBackService = cashBackService;
        }

        public ICommandResult Handle(NewOrder command)
        {
            OrderCashBack orderCashBack = _cashBackService.CalculateOrderCashBack(command.Order);
            _orderCashBackRepository.Add(orderCashBack);

            AddNotifications(orderCashBack.Notifications);

            if (Valid)
            {
                return new ClientResult();
            }
            else
            {
                return null;
            }
        }
    }
}
