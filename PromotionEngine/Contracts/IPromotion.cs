using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Contracts
{
    public interface IPromotion
    {
        double CalculatePrice(IDictionary<string, double> priceList, IDictionary<string, int> orderList);
    }
}
