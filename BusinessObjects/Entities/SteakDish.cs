using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public class SteakDish:Dish
    {
        public override EDishType DishType
        {
            get { return EDishType.Entree; }
        }

        protected override string DishName
        {
            get { return "steak"; }
        }
    }
}
