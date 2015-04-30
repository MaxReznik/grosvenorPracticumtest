using Contracts;
using GrosvenorPracticumTest.TestConstants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrosvenorPracticumTest
{
    /// <summary>
    /// Summary description for NotAvailableValidatorTest
    /// </summary>
    [TestClass]
    public class NotAvailableValidatorTest
    {
        NotAvailableValidatorStep step = new NotAvailableValidatorStep();
        
        [TestMethod]
        public void ValidateCorrectOrderTest()
        {
            var order = OrderTestHelper.CreateValidNaTest();
            step.Validate(order);
            Assert.IsFalse(order.FirstError.HasValue);
        }

        [TestMethod]
        public void ValidateIncorrectOrderTest()
        {
            var order = OrderTestHelper.CreateInvalidNaTestInvalidIndexIs1();
            step.Validate(order);
            Assert.AreEqual(1, order.FirstError.Value);
        }

        [TestMethod]
        public void ValidateAlreadyValidatedInvalidOrderErrorIndexDoesNotChangeTest()
        {
            var order = OrderTestHelper.CreateInvalidNaTestInvalidIndexIs1();
            order.FirstError = 0;
            step.Validate(order);
            Assert.AreEqual(0, order.FirstError.Value);
        }

        [TestMethod]
        public void ValidateAlreadyValidatedInvalidOrderErrorIndexChangesTest()
        {
            var order = OrderTestHelper.CreateInvalidNaTestInvalidIndexIs1();
            order.FirstError = 2;
            step.Validate(order);
            Assert.AreEqual(1, order.FirstError.Value);
        }
    }
}
