using BusinessObjects.Entities;
using Contracts.Factories;
using Contracts.Interfaces.Validation;

namespace Contracts
{
    public class MaxCountValidationStep : IValidationStep
    {
        public void Validate(Order order)
        {
            var dict = MaxCountValidationFactory.Create(order.OrderType);
            int length = order.FirstError ?? order.Dishes.Count;
            for (int i = 0; i < length; i++)
            {
                var dish = order.Dishes[i];
                var validator = dict[dish.DishType];
                validator.Increment();
                if (!validator.IsValid)
                {
                    order.FirstError = i;
                    break;
                }
            }
        }
    }
}