using BusinessObjects.Entities;
using Contracts.Interfaces.Validation;

namespace Contracts
{
    public class OrderValidator : IOrderValidator
    {
        private IValidationStep[] Validators;

        public OrderValidator(IValidationStep[] validators)
        {
            Validators = validators;
        }


        public void Validate(Order order)
        {
            if (Validators == null) return;

            foreach (var step in Validators)
            {
                step.Validate(order);
            }
        }
    }

    public class CountValidation
    {
        private readonly int _maxCount;
        private int _currentCount;

        public CountValidation(int maxCount)
        {
            _maxCount = maxCount;
        }

        public void Increment()
        {
            _currentCount++;
        }

        public bool IsValid
        {
            get
            {
                return _currentCount <= _maxCount;
            }
        }
    }
}
