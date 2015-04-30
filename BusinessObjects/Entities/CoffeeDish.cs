using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public class CoffeeDish:Dish
    {
        public override EDishType DishType
        {
            get { return EDishType.Drink; }
        }

        protected override string DishName
        {
            get { return "coffee"; }
        }
    }
}
