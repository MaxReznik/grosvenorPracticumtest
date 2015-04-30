using System.Collections.Generic;
using BusinessObjects.Enums;

namespace Contracts.Factories
{
    public static class MaxCountValidationFactory
    {
        public static Dictionary<EDishType, CountValidation> Create(EOrderType orderType)
        {
            var result = new Dictionary<EDishType, CountValidation>();
            switch (orderType)
            {
                case EOrderType.Morning:
                    result.Add(EDishType.Entree, new CountValidation(1));
                    result.Add(EDishType.Side, new CountValidation(1));
                    result.Add(EDishType.Drink, new CountValidation(int.MaxValue));
                    result.Add(EDishType.Desert, new CountValidation(0));
                    result.Add(EDishType.NotAvailable, new CountValidation(0));
                    break;
                case EOrderType.Night:
                    result.Add(EDishType.Entree, new CountValidation(1));
                    result.Add(EDishType.Side, new CountValidation(int.MaxValue));
                    result.Add(EDishType.Drink, new CountValidation(1));
                    result.Add(EDishType.Desert, new CountValidation(1));
                    result.Add(EDishType.NotAvailable, new CountValidation(0));
                    break;
            }
            return result;
        }
    }
}
