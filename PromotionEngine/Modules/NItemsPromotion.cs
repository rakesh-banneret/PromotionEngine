using PromotionEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Modules
{
    public class NItemsPromotion : IPromotion
    {
        public double CalculatePrice(IDictionary<string, double> priceList, IDictionary<string, int> orderList)
        {
            throw new NotImplementedException();
        }
    }
}
