using PromotionEngine.Contracts;
using PromotionEngine.Modules;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PromotionEngine.Engine
{
    public class PromoEngine
    {
        ReadOnlyCollection<IPromotion> promotions;

        public PromoEngine() : this(new List<IPromotion> { new DefaultPromotion() }) { }

        public PromoEngine(IList<IPromotion> promotions)
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
