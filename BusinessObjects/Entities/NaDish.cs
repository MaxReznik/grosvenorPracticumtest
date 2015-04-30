using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public class NaDish: Dish
    {
        public override EDishType DishType
        {
            get { return EDishType.NotAvailable; }
        }

        protected override string DishName
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
