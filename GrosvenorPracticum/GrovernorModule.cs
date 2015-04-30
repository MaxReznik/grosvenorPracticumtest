using Contracts;
using Contracts.Interfaces;
using Contracts.Interfaces.Validation;
using GrosvenorPracticum.Services;
using Ninject.Modules;

namespace GrosvenorPracticum
{
    class GrovernorModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderTrimmer>().To<OrderTrimmer>();
            Bind<IDataToOrderConverter<string>>().To<StringToOrderConverter>();
            Bind<IDishSorter>().To<DishSorter>();
            Bind<IOrderOututGenerator<string>>().To<OutputGenerator>();
            Bind<IValidationStep>().To<MaxCountValidationStep>();
            Bind<IValidationStep>().To<NotAvailableValidatorStep>();
            Bind<IOrderValidator>().To<OrderValidator>();
            Bind<IOrderManager<string, string>>().To<OrderManager>();
        }
    }
}
