using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public class WineDish: Dish
    {
        public override EDishType DishType
        {
            get { return EDishType.Drink; }
        }

        protected override string DishName
        {
            get { return "wine"; }
        }
    }
}
