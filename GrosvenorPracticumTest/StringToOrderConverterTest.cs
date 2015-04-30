using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Contracts;
using Contracts.Interfaces;
using GrosvenorPracticum;
using GrosvenorPracticum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrosvenorPracticumTest
{
    [TestClass]
    public class StringToOrderConverterTest
    {
        private const string MorningStr = "MOrnIng";
        private const string EveningStr = "nIGhT";
        private const string Entree = "1";
        private const string Side = "2";
        private const string Drink = "3";
        private const string Desert = "4";
        private const string WrongDish = "5";

        readonly StringToOrderConverter _converter = new StringToOrderConverter();
        EOrderType morning = EOrderType.Morning;
        EOrderType evening = EOrderType.Night;
        
        [TestMethod]
        public void OrderTypeParseTestSuccess()
        {
            // parser is not case sensitive, should be able to parse any variation of 'morning' and 'evening'
            var morningResult = _converter.TryParse(MorningStr);
            Assert.AreEqual(morning, morningResult.OrderType);
            var eveningResult = _converter.TryParse(EveningStr);
            Assert.AreEqual(evening, eveningResult.OrderType);
        }

        [TestMethod]
        public void ConversionNumbersToDishesTest()
        {
            var result = _converter.TryParse(string.Join(",", MorningStr, Entree, Side, Drink, Desert, WrongDish));

            Assert.AreEqual(EDishType.Entree, result.Dishes[0].DishType);
            Assert.IsInstanceOfType(result.Dishes[0], typeof (EggsDish));
            Assert.AreEqual(EDishType.Side, result.Dishes[1].DishType);
            Assert.IsInstanceOfType(result.Dishes[1], typeof(ToastDish));
            Assert.AreEqual(EDishType.Drink, result.Dishes[2].DishType);
            Assert.IsInstanceOfType(result.Dishes[2], typeof(CoffeeDish));
            Assert.AreEqual(EDishType.NotAvailable, result.Dishes[3].DishType);
            Assert.IsInstanceOfType(result.Dishes[3], typeof(NaDish));
            Assert.AreEqual(EDishType.NotAvailable, result.Dishes[4].DishType);
            Assert.IsInstanceOfType(result.Dishes[4], typeof(NaDish));

            result = _converter.TryParse(string.Join(",", EveningStr, Entree, Side, Drink, Desert, WrongDish));

            Assert.AreEqual(EDishType.Entree, result.Dishes[0].DishType);
            Assert.IsInstanceOfType(result.Dishes[0], typeof(SteakDish));
            Assert.AreEqual(EDishType.Side, result.Dishes[1].DishType);
            Assert.IsInstanceOfType(result.Dishes[1], typeof(PotatoDish));
            Assert.AreEqual(EDishType.Drink, result.Dishes[2].DishType);
            Assert.IsInstanceOfType(result.Dishes[2], typeof(WineDish));
            Assert.AreEqual(EDishType.Desert, result.Dishes[3].DishType);
            Assert.IsInstanceOfType(result.Dishes[3], typeof(CakeDish));
            Assert.AreEqual(EDishType.NotAvailable, result.Dishes[4].DishType);
            Assert.IsInstanceOfType(result.Dishes[4], typeof(NaDish));
        }
    }
}
