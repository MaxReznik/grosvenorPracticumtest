using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public class CakeDish: Dish
    {
        public override EDishType DishType
        {
            get { return EDishType.Desert; }
        }

        protected override string DishName
        {
            get { return "cake"; }
        }
    }
}
