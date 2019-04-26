using Domain.Entities;
using Domain.Enumerators;
using Domain.Interfaces.Services;
using System;

namespace Domain.Services
{
    public class CashBackService : ICashBackService
    {

        public CashBackService()
        {
        }

        public OrderCashBack CalculateOrderCashBack(Order order)
        {
            OrderCashBack orderCashBack = new OrderCashBack(order);

            foreach (var orderItem in order.OrderItems)
            {
                decimal cp = GetCashbackPercentage(order.Date.DayOfWeek, orderItem.Disk.Genre);
                orderCashBack.AddCashbackOrderItem(new OrderCashBackItem(orderItem, cp));
            }

            return orderCashBack;
        }

        private decimal GetCashbackPercentage(DayOfWeek day, EDiskGenre genre)
        {
            switch (genre)
            {
                case EDiskGenre.POP:
                    return ReturnPopPer(day);
                case EDiskGenre.MPB:
                    return ReturnMPBPer(day);
                case EDiskGenre.CLASSIC:
                    return ReturnClassicPer(day);
                case EDiskGenre.ROCK:
                    return ReturnRockPer(day);
                default:
                    throw new Exception("Não é possível retornar o cahback pois o gênero não foi encontrado");
            }            
        }


        private decimal ReturnPopPer(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return 25;
                case DayOfWeek.Monday:
                    return 7;
                case DayOfWeek.Tuesday:
                    return 6;
                case DayOfWeek.Wednesday:
                    return 2;
                case DayOfWeek.Thursday:
                    return 10;
                case DayOfWeek.Friday:
                    return 15;
                case DayOfWeek.Saturday:
                    return 20;
                default:
                    return 0;
            }
        }

        private decimal  ReturnMPBPer(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return 30;
                case DayOfWeek.Monday:
                    return 5;
                case DayOfWeek.Tuesday:
                    return 10;
                case DayOfWeek.Wednesday:
                    return 15;
                case DayOfWeek.Thursday:
                    return 20;
                case DayOfWeek.Friday:
                    return 25;
                case DayOfWeek.Saturday:
                    return 30;
                default:
                    return 0;
            }
        }

        private decimal ReturnClassicPer(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return 35;
                case DayOfWeek.Monday:
                    return 3;
                case DayOfWeek.Tuesday:
                    return 5;
                case DayOfWeek.Wednesday:
                    return 8;
                case DayOfWeek.Thursday:
                    return 13;
                case DayOfWeek.Friday:
                    return 18;
                case DayOfWeek.Saturday:
                    return 25;
                default:
                    return 0;
            }
        }

        private decimal ReturnRockPer(DayOfWeek day)
        {

            switch (day)
            {
                case DayOfWeek.Sunday:
                    return 40;
                case DayOfWeek.Monday:
                    return 10;
                case DayOfWeek.Tuesday:
                    return 15;
                case DayOfWeek.Wednesday:
                    return 15;
                case DayOfWeek.Thursday:
                    return 15;
                case DayOfWeek.Friday:
                    return 20;
                case DayOfWeek.Saturday:
                    return 40;
                default:
                    return 0;
            }          
        }
    }
}
