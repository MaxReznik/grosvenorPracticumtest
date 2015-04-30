using System.Collections.Generic;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Contracts;
using GrosvenorPracticumTest.TestConstants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrosvenorPracticumTest
{
    [TestClass]
    public class DishSorterTest
    {
        readonly DishSorter _sorter = new DishSorter();

        [TestMethod]
        public void SortTestNoError()
        {
            Order order = new Order(EOrderType.Morning);
            order.Dishes.AddRange(new List<Dish>
            {
                DishConstants.Cake,
                DishConstants.Coffee,
                DishConstants.Eggs,
                DishConstants.Potatoes,
                DishConstants.Steak,
                DishConstants.Toast,
                DishConstants.Wine
            });
            _sorter.Sort(order);
            EDishType lastDishType = EDishType.Entree;

            foreach (var dish in order.Dishes)
            {
                Assert.IsTrue(dish.DishType>=lastDishType);
                lastDishType = dish.DishType;
            }
        }

        [TestMethod]
        public void SortTestWithError()
        {
            Order order = new Order(EOrderType.Morning);
            order.FirstError = 3;
            var initialOrder = new List<Dish>
            {
                DishConstants.Coffee,
                DishConstants.Eggs,
                DishConstants.Toast,
                DishConstants.Toast
            };

            order.Dishes.AddRange(initialOrder);
            _sorter.Sort(order);
            for (int i = 0; i < order.Dishes.Count; i++)
            {
                Assert.AreEqual(initialOrder[i], order.Dishes[i]);
            }
        }
    }
}
