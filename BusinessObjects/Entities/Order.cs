using System.Collections.Generic;
using BusinessObjects.Enums;

namespace BusinessObjects.Entities
{
    public class Order
    {
        public Order(EOrderType orderType)
        {
            OrderType = orderType;
            Dishes = new List<Dish>();
        }
        public EOrderType OrderType { get; private set; }
        public List<Dish> Dishes { get; private set; }
        public int? _firstErorIndex;

        public int? FirstError
        {
            get { return _firstErorIndex; }
            set
            {
                if (_firstErorIndex.HasValue && _firstErorIndex.Value <= value)
                    return;
                _firstErorIndex = value;
            }
        }
    }
}
