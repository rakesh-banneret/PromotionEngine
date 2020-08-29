using PromotionEngine.Contracts;
using System.Collections.Generic;

namespace PromotionEngine.Modules
{
    public class DefaultPromotion : IPromotion
    {
        public double CalculatePrice(IDictionary<string, double> priceList, IDictionary<string, int> orderList)
        {
            var total = 0.0;

            foreach (var item in orderList)
            {
                total += priceList[item.Key] * item.Value;
            }

            return total;
        }
    }
}
