using PromotionEngine.Contracts;
using PromotionEngine.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PromotionEngine.Engine
{
    public class PromotionEngine
    {
        ReadOnlyCollection<IPromotion> promotions;

        public PromotionEngine() : this(new List<IPromotion> { new DefaultPromotion() }) { }

        public PromotionEngine(IList<IPromotion> promotions)
        {
            this.promotions = new ReadOnlyCollection<IPromotion>(promotions);
        }

        public double CalculatePrice(IDictionary<string,double> priceList, IDictionary<string,int> orderList)
        {
            var tempOrder = new Dictionary<string, int>();
            foreach(var item in orderList)
            {
                tempOrder[item.Key] = item.Value;
            }

            return promotions.Sum(a => a.CalculatePrice(priceList, tempOrder));
        }
    }
}
