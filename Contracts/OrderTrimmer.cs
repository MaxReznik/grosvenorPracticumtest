using System.Collections.Generic;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Contracts.Interfaces;

namespace Contracts
{
    public class OrderTrimmer:IOrderTrimmer
    {
        public void TrimOrder(Order order)
        {
            if (order.FirstError.HasValue) return;
            var dict = new Dictionary<EDishType, Dish>();
            var removeList = new List<Dish>();

            foreach (var dish in order.Dishes)
            {
                if (dict.ContainsKey(dish.DishType))
                {
                    dict[dish.DishType].Count++;
                    removeList.Add(dish);
                }
                else
                {
                    dict.Add(dish.DishType, dish);
                }
            }

            foreach (var dish in removeList)
            {
                order.Dishes.Remove(dish);
            }
        }
    }
}
