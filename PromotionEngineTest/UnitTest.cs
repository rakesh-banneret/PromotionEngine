using NUnit.Framework;
using System.Collections.Generic;
using PromotionEngine.Engine;

namespace PromotionEngineTest
{
    public class Tests
    {
        Dictionary<string, double> priceList = new Dictionary<string, double> { { "A", 50 }, { "B", 30 }, { "C", 20 }, { "D", 15 } };

        [SetUp]
        public void Setup()
        {
        }

        
        [Test]
        public void DefaultPromotion()
        {

            var pEngine = new PromoEngine();
            var orderList = new Dictionary<string, int> { { "A", 1 }, { "B", 1 }, { "C", 1 } };

            var result = pEngine.CalculatePrice(priceList, orderList);

            Assert.AreEqual(100, result);
        }
    }
}