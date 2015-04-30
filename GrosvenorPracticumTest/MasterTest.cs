using Contracts;
using Contracts.Interfaces;
using Contracts.Interfaces.Validation;
using GrosvenorPracticum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrosvenorPracticumTest
{
    [TestClass]
    public class MasterTest
    {
        private IOrderManager<string, string> GetOrderManager()
        {
            var validator = new OrderValidator(new IValidationStep[] {new MaxCountValidationStep(), new NotAvailableValidatorStep()});
            var orderManager = new OrderManager(new StringToOrderConverter(), validator, new DishSorter(),
                new OutputGenerator(), new OrderTrimmer());
            return orderManager;
        }
        
        [TestMethod]
        public void MasterTestMethod()
        {
            string[] inputs = {
                "morning, 1, 2, 3",
                "morning, 2, 1, 3",
                "morning, 1, 2, 3, 4",
                "morning, 1, 2, 3, 3, 3",
                "night, 1, 2, 3, 4",
                "night, 1, 2, 2, 4",
                "night, 1, 2, 3, 5",
                "night, 1, 1, 2, 3, 5"
            };

            string[] expectedResults = {
                "eggs, toast, coffee",
                "eggs, toast, coffee",
                "eggs, toast, coffee, error",
                "eggs, toast, coffee(x3)",
                "steak, potato, wine, cake",
                "steak, potato(x2), cake",
                "steak, potato, wine, error",
                "steak, error"
            };

            var orderManager = GetOrderManager();
            for (int i = 0; i < inputs.Length; i++)
            {
                Assert.AreEqual(expectedResults[i], orderManager.ProcessOrder(inputs[i]));
            }
        }
    }
}
