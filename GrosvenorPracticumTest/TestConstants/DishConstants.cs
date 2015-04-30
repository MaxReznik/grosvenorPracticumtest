using BusinessObjects.Entities;

namespace GrosvenorPracticumTest.TestConstants
{
    internal static class DishConstants
    {
        public static CakeDish Cake
        {
            get { return new CakeDish(); }
        }

        public static CoffeeDish Coffee
        {
            get { return new CoffeeDish(); }
        }

        public static EggsDish Eggs
        {
            get { return new EggsDish(); }
        }

        public static PotatoDish Potatoes { get { return new PotatoDish(); } }
        public static SteakDish Steak {get { return new SteakDish(); }}
        public static ToastDish Toast { get { return new ToastDish(); } }
        public static NaDish NaDish { get { return new NaDish();} }
        public static WineDish Wine
        {
            get { return new WineDish(); }
        }

        public static CoffeeDish Coffeex3 {get { return new CoffeeDish {Count = 3}; }}
        public static PotatoDish Potatoesx3 { get { return new PotatoDish{Count = 3}; } }
    }
}
