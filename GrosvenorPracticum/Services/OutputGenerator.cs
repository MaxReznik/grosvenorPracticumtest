using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Entities;
using Contracts.Interfaces;

namespace GrosvenorPracticum.Services
{
    public class OutputGenerator: IOrderOututGenerator<string>
    {
        public string GenerateResult(Order order)
        {
            List<string> desc = new List<string>();
            if (order.FirstError.HasValue)
            {
                for (int i = 0; i < order.FirstError.Value; i++)
                {
                    desc.Add(order.Dishes[i].DishDescription);
                }
                desc.Add("error");
            }
            else desc = order.Dishes.Select(x => x.DishDescription).ToList();
            
            return string.Join(", ", desc);
        }
    }
}
