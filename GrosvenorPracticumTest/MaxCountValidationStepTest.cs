using Contracts;
using GrosvenorPracticumTest.TestConstants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrosvenorPracticumTest
{
    [TestClass]
    public class MaxCountValidationStepTest
    {
        MaxCountValidationStep step = new MaxCountValidationStep();

        [TestMethod]
        public void ValidateCorrectOrderTest()
        {
            var order = OrderTestHelper.CreateValidMorningOrder();

            step.Validate(order);
            Assert.IsFalse(order.FirstError.HasValue);

            order = OrderTestHelper.CreateValidMorningOrderWith3CupsOfCoffee();
            step.Validate(order);
            Assert.IsFalse(order.FirstError.HasValue);

            order = OrderTestHelper.CreateValidNightOrder();
            step.Validate(order);
            Assert.IsFalse(order.FirstError.HasValue);

            order = OrderTestHelper.CreateValidNightOrderWithMultipleServingsOfPotatoes();
            step.Validate(order);
            Assert.IsFalse(order.FirstError.HasValue);
        }

        [TestMethod]
        public void ValidateIncorrectOrderTest()
        {
            var order = OrderTestHelper.CreateInvalidMorningOrderWrongSecondItem();
            step.Validate(order);
            Assert.AreEqual(2, order.FirstError.Value);

            order = OrderTestHelper.CreateInvalidNightOrderWronSecondItem();
            step.Validate(order);
            Assert.AreEqual(2, order.FirstError.Value);
        }

        [TestMethod]
        public void ValidateAlreadyValidatedInvalidOrderErrorIndexDoesNotChangeTest()
        {
            var order = OrderTestHelper.CreateValidatedInvalidOrderInvalidIndexIs2();
            order.FirstError = 1;
            step.Validate(order);
            Assert.AreEqual(1, order.FirstError.Value);
        }

        [TestMethod]
        public void ValidateAlreadyValidatedInvalidOrderErrorIndexChangesTest()
        {
            var order = OrderTestHelper.CreateValidatedInvalidOrderInvalidIndexIs2();
            order.FirstError = 3;
            step.Validate(order);
            Assert.AreEqual(2, order.FirstError.Value);
        }
    }
}
