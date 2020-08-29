using PromotionEngine.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Modules
{
    public class AndPromotion : IPromotion
    {
        readonly string[] propProds;
        double promPrice;

        public AndPromotion(string[] propProds, double promPrice)
        {
            this.propProds = propProds;
            this.promPrice = promPrice;
        }
        public double CalculatePrice(IDictionary<string, double> priceList, IDictionary<string, int> orderList)
        {
            if (!propProds.All(a => orderList.ContainsKey(a)))
            {
                return 0;
            }

            var minQtyToApplyPromo = propProds.Min(a => orderList[a]);

            foreach (var item in propProds)
            {
                orderList[item] -= minQtyToApplyPromo;
            }

            return promPrice;
        }
    }
}
