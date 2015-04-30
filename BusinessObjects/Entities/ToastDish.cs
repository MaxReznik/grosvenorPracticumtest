using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public class ToastDish:Dish
    {
        public override EDishType DishType
        {
            get { return EDishType.Side; }
        }

        protected override string DishName
        {
            get { return "toast"; }
        }
    }
}
