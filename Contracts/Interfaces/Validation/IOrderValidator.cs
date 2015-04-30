using BusinessObjects.Entities;

namespace Contracts.Interfaces.Validation
{
    public interface IOrderValidator
    {
        void Validate(Order order);
    }
}
