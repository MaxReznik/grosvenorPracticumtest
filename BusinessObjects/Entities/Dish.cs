using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public abstract class Dish
    {
        protected Dish()
        {
            Count = 1;
        }
        public abstract EDishType DishType { get; }
        public int Count { get; set; }
        protected abstract string DishName { get; }

        public string DishDescription
        {
            get
            {
                string countSuffix = Count > 1 ? string.Format("(x{0})", Count) : string.Empty;
                return DishName + countSuffix;
            }
        }
    }
}
