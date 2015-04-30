using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Contracts;
using GrosvenorPracticum;
using GrosvenorPracticum.Services;
using GrosvenorPracticumTest.TestConstants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrosvenorPracticumTest
{
    [TestClass]
    public class OutputGeneratorTest
    {
        
        OutputGenerator gen = new OutputGenerator();

        [TestMethod]
        public void GenerateOutputForOrderWithoutErrors()
        {
            var dishes = new Dish[]
            {
                DishConstants.Coffee, DishConstants.Eggs, DishConstants.Cake, DishConstants.Potatoes, DishConstants.Steak, DishConstants.Toast, DishConstants.Wine
            };
            var result = gen.GenerateResult(OrderTestHelper.CreateOrder(EOrderType.Morning, null, dishes.ToArray()));
            List<string> expectedList = new List<string>(dishes.Length);
            expectedList.AddRange(dishes.Select(dish => dish.DishDescription));

            Assert.AreEqual(string.Join(", ", expectedList.ToArray()), result);
        }

        [TestMethod]
        public void GenerateOutputForOrderWithError()
        {
            var dishes = new Dish[]
            {
                DishConstants.Steak,DishConstants.Steak,DishConstants.Potatoes,DishConstants.Wine
            };
            var result = gen.GenerateResult(OrderTestHelper.CreateOrder(EOrderType.Night, 1, dishes));
            Assert.AreEqual("steak, error", result);
        }

        [TestMethod]
        public void GenerateOutputWithMultipleItems()
        {
            var dishes = new Dish[]
            {
                DishConstants.Coffeex3
            };
            var result = gen.GenerateResult(OrderTestHelper.CreateOrder(EOrderType.Morning, null, dishes));
            Assert.AreEqual("coffee(x3)", result);
        }

        
        
    }
}
