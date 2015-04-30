using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrosvenorPracticumTest
{
    [TestClass]
    public class OrderTrimmerTest
    {
        OrderTrimmer trimmer = new OrderTrimmer();
        [TestMethod]
        public void TestMethod1()
        {
            Order order = new Order(EOrderType.Morning);
            order.Dishes.Add(new CoffeeDish());
            order.Dishes.Add(new CoffeeDish());
            order.Dishes.Add(new CoffeeDish());

            
            trimmer.TrimOrder(order);

            Assert.AreEqual(1,order.Dishes.Count);
            Assert.AreEqual(3, order.Dishes[0].Count);
        }

        [TestMethod]
        public void OrderGroupingWithError()
        {
            Order order = new Order(EOrderType.Night);
            order.FirstError = 1;
            order.Dishes.Add(new CakeDish());
            order.Dishes.Add(new CakeDish());
            order.Dishes.Add(new CakeDish());
            trimmer.TrimOrder(order);

            Assert.AreEqual(3, order.Dishes.Count);
            foreach (var dish in order.Dishes)
            {
                Assert.AreEqual(1, dish.Count);
            }
        }
    }
}
