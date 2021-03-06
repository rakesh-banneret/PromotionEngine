﻿using System.Collections.Generic;

namespace PromotionEngine.Contracts
{
    public interface IPromotion
    {
        double CalculatePrice(IDictionary<string, double> priceList, IDictionary<string, int> orderList);
    }
}
