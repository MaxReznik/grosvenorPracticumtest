using BusinessObjects.Entities;

namespace Contracts.Interfaces
{
    public interface IDataToOrderConverter<in TInput>
    {
        Order TryParse(TInput input);
    }
}
