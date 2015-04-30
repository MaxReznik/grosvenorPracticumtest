using BusinessObjects.Entities;

namespace Contracts.Interfaces.Validation
{
    public interface IValidationStep
    {
        void Validate(Order order);
    }
}
