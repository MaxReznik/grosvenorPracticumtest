using BusinessObjects.Entities;

namespace Contracts.Interfaces
{
    public interface IOrderOututGenerator<out TOutput>
    {
        TOutput GenerateResult(Order order);
    }
}
