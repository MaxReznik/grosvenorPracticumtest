using System;
using System.Linq;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Contracts.Factories;
using Contracts.Interfaces;

namespace GrosvenorPracticum.Services
{
    public class StringToOrderConverter : IDataToOrderConverter<string>
    {
        public Order TryParse(string input)
        {
            var inputs = input.Split(',');
            if (!inputs.Any()) return null;

            var result = new Order(GetOrderType(inputs[0]));

            for (int i = 1; i < inputs.Length; i++)
            {
                result.Dishes.Add(DishFactory.CreateDish(result.OrderType, Convert.ToInt32(inputs[i].Trim())));
            }

            return result;
        }

        private EOrderType GetOrderType(string element)
        {
            if (element.ToLower() == "morning") return EOrderType.Morning;
            if (element.ToLower() == "night") return EOrderType.Night;
            throw new Exception(string.Format("{0} can't be converter to Order Type", element));
        }
    }
}
