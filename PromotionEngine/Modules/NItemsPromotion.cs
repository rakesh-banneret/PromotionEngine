using PromotionEngine.Contracts;
using System.Collections.Generic;

namespace PromotionEngine.Modules
{
    public class NItemsPromotion : IPromotion
    {
        string itemName;
        int itemQty;
        double promPrice;

        public NItemsPromotion(string itemName, int itemQty, double promPrice)
        {
            this.itemName = itemName;
            this.itemQty = itemQty;
            this.promPrice = promPrice;
        }
        public double CalculatePrice(IDictionary<string, double> priceList, IDictionary<string, int> orderList)
        {
            if (!orderList.ContainsKey(itemName)) return 0;

            var orderedQty = orderList[itemName];

            if (orderedQty < itemQty) return 0;

            var numOfItemSet = orderedQty / itemQty;

            orderList[itemName] = orderList[itemName] - (numOfItemSet * itemQty);

            return numOfItemSet * promPrice;
        }
    }
}
