using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public class PotatoDish:Dish
    {
        public override EDishType DishType
        {
            get { return EDishType.Side; }
        }

        protected override string DishName
        {
            get { return "potato"; }
        }
    }
}
