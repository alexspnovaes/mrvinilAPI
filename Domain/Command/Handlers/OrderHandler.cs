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

namespace Domain.Command.Handlers
{
    public class OrderHandler : Notifiable, ICommandHandler<NewBasket>
    {
        //injection        
        private readonly IClientRepository _clientRepository;
        private readonly IDiskRepository _diskRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderCashBackRepository _orderCashBackRepository;
        private readonly ICashBackService _cashBackService;
        public OrderHandler(IClientRepository clientRepository,IDiskRepository diskRepository, IOrderRepository orderRepository, IOrderCashBackRepository orderCashBackRepository, ICashBackService cashBackService)
        {
            _clientRepository = clientRepository;
            _diskRepository = diskRepository;
            _orderRepository = orderRepository;
            _orderCashBackRepository = orderCashBackRepository;
            _cashBackService = cashBackService;
        }

        public ICommandResult Handle(NewBasket command)
        {
            // Instancia o cliente (Lendo do repositorio)
            var client = _clientRepository.GetById(command.ClientId);

            //listar itens
            List<OrderItem> items = new List<OrderItem>();

            // Gera um novo pedido
            var order = new Order(client);

            foreach (var item in command.Items)
            {
                //Instancia o disk(Lendo do repositorio)
                var disk = _diskRepository.GetById(item.DiskId);
                order.AddOrderItem(new OrderItem(disk, item.UnitPrice, item.Quantity));
            }

            

            //gerar cashback
            var cashback = _cashBackService.CalculateOrderCashBack(order);

            // Adiciona as notificações do Pedido no Handler
            AddNotifications(order.Notifications);            

            // Persiste no banco
            if (Valid)
            {
                _orderRepository.AddAndSave(order,cashback);                             
            }
            return new OrderResult(order.Number);
        }

    }
}
