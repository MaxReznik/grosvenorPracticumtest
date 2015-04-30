using Contracts.Interfaces;
using Contracts.Interfaces.Validation;

namespace GrosvenorPracticum.Services
{
    public class OrderManager : IOrderManager<string,string>
    {
        public IDataToOrderConverter<string> Converter { get; set; }
        public IOrderValidator OrderValidator { get; set; }
        public IDishSorter DishSorter { get; set; }
        public IOrderOututGenerator<string> OutputGenerator { get; set; }
        public IOrderTrimmer Trimmer { get; set; }

        public OrderManager(IDataToOrderConverter<string> converter, IOrderValidator validator, IDishSorter sorter,
            IOrderOututGenerator<string> generator, IOrderTrimmer trimmer)
        {
            Converter = converter;
            OrderValidator = validator;
            DishSorter = sorter;
            OutputGenerator = generator;
            Trimmer = trimmer;
        }

        public string ProcessOrder(string input)
        {
            var order = Converter.TryParse(input);
            OrderValidator.Validate(order);
            Trimmer.TrimOrder(order);
            DishSorter.Sort(order);
            return OutputGenerator.GenerateResult(order);
        }
    }
}
