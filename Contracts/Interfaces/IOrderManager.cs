namespace Contracts.Interfaces
{
    public interface IOrderManager<in TInput, out TOutput>
    {
        TOutput ProcessOrder(TInput input);
    }
}
