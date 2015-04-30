using System.Linq;
using BusinessObjects.Entities;
using Contracts.Interfaces;

namespace Contracts
{
    public class DishSorter: IDishSorter
    {
        public void Sort(Order order)
        {
            if (order.FirstError.HasValue) return;
            var dishes = order.Dishes.OrderBy(x => x.DishType).ToList();
            order.Dishes.Clear();
            order.Dishes.AddRange(dishes);
        }
    }
}
