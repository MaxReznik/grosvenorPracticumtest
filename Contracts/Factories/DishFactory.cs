using BusinessObjects.Entities;
using BusinessObjects.Enums;

namespace Contracts.Factories
{
    public static class DishFactory
    {
        public static Dish CreateDish(EOrderType orderType, int input)
        {
            if (orderType == EOrderType.Morning)
            {
                switch (input)
                {
                    case 1: return new EggsDish();
                    case 2: return new ToastDish();
                    case 3: return new CoffeeDish();
                    case 4: return new NaDish();
                    default: return new NaDish();
                }
            }
            if (orderType == EOrderType.Night)
            {
                switch (input)
                {
                    case 1: return new SteakDish();
                    case 2: return new PotatoDish();
                    case 3: return new WineDish();
                    case 4: return new CakeDish();
                    default: return new NaDish();
                }
            }
            return null;
        }
    }
}
