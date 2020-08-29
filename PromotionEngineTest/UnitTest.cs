using NUnit.Framework;
using System.Collections.Generic;
using PromotionEngine.Engine;
using PromotionEngine.Contracts;
using PromotionEngine.Modules;

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

        [Test]
        public void DefaultPromotion2()
        {
            var pEngine = new PromoEngine();
            var orderList = new Dictionary<string, int> { { "A", 1 }, { "B", 1 }, { "C", 1 }, { "D", 1 } };

            var result = pEngine.CalculatePrice(priceList, orderList);

            Assert.AreEqual(115, result);
        }

        [Test]
        [TestCase(1, 50)]
        [TestCase(2, 100)]
        [TestCase(3, 130)]
        [TestCase(5, 230)]
        [TestCase(7, 310)]
        public void NItemsTest2(int Qty, double expectedPrice)
        {
            var pEngine = new PromoEngine(new List<IPromotion> { new NItemsPromotion("A", 3, 130), new DefaultPromotion() });

            var orderList = new Dictionary<string, int> { { "A", Qty } };

            var result = pEngine.CalculatePrice(priceList, orderList);

            Assert.AreEqual(expectedPrice, result);
        }

        [Test]
        public void AllPromoTest()
        {
            var pEngine = new PromoEngine(new List<IPromotion> { new NItemsPromotion("A", 3, 130),
                new NItemsPromotion("B", 2, 45), new AndPromotion(new[]{"C","D" }, 30), new DefaultPromotion() });

            var orderList = new Dictionary<string, int> { { "A", 5 }, { "B", 5 }, { "C", 1 } };

            var result = pEngine.CalculatePrice(priceList, orderList);

            Assert.AreEqual(370, result);
        }
    }
}