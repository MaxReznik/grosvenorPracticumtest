using BusinessObjects.Entities;

namespace Contracts.Interfaces
{
    public interface IOrderTrimmer
    {
        void TrimOrder(Order order);
    }
}
