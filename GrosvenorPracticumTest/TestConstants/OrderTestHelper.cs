using BusinessObjects.Entities;
using BusinessObjects.Enums;

namespace GrosvenorPracticumTest.TestConstants
{
    class OrderTestHelper
    {
        public static Order CreateOrder(EOrderType orderType, int? errorIndex, params Dish[] dishes)
        {
            var order = new Order(orderType);
            if (errorIndex.HasValue) order.FirstError = errorIndex.Value;
            foreach (var dish in dishes)
            {
                order.Dishes.Add(dish);
            }
            return order;
        }

        public static Order CreateValidMorningOrder()
        {
            return CreateOrder(EOrderType.Morning, null, DishConstants.Eggs, DishConstants.Toast,
                DishConstants.Coffee);
        }

        public static Order CreateInvalidMorningOrderWrongSecondItem()
        {
            return CreateOrder(EOrderType.Morning, null, DishConstants.Eggs, DishConstants.Toast,
                DishConstants.Toast);
        }

        public static Order CreateValidMorningOrderWith3CupsOfCoffee()
        {
            return CreateOrder(EOrderType.Morning, null, DishConstants.Eggs, DishConstants.Toast,
                DishConstants.Coffeex3);
        }

        public static Order CreateValidNightOrder()
        {
            return CreateOrder(EOrderType.Night, null, DishConstants.Steak, DishConstants.Potatoes, DishConstants.Wine);
        }

        public static Order CreateValidNightOrderWithMultipleServingsOfPotatoes()
        {
            return CreateOrder(EOrderType.Night, null, DishConstants.Steak, DishConstants.Potatoesx3, DishConstants.Wine);
        }

        public static Order CreateInvalidNightOrderWronSecondItem()
        {
            return CreateOrder(EOrderType.Night, null, DishConstants.Steak, DishConstants.Potatoes, DishConstants.Steak);
        }

        public static Order CreateValidatedInvalidOrderInvalidIndexIs2()
        {
            return CreateOrder(EOrderType.Morning, null, DishConstants.Eggs, DishConstants.Toast, DishConstants.Toast);
        }

        public static Order CreateValidNaTest()
        {
            return CreateValidNightOrder();
        }

        public static Order CreateInvalidNaTestInvalidIndexIs1()
        {
            return CreateOrder(EOrderType.Morning, null, DishConstants.Eggs, DishConstants.NaDish, DishConstants.Toast, DishConstants.Toast);
        }
    }
}
