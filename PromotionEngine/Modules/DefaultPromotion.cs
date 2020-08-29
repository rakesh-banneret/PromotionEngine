using PromotionEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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
