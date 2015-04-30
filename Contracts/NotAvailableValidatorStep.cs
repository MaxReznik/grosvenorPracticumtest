using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Contracts.Interfaces.Validation;

namespace Contracts
{
    public class NotAvailableValidatorStep : IValidationStep
    {
        public void Validate(Order order)
        {
            var naDishIndex = order.Dishes.FindIndex(0, x => x.DishType == EDishType.NotAvailable);
            if (naDishIndex >= 0)
            {
                order.FirstError = naDishIndex;
            }
        }
    }
}