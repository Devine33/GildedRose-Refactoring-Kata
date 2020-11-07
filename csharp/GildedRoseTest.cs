using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private GildedRose _gildedRose;
        private IList<Item> _itemList;

        [SetUp]
        public void Setup()
        {
            _itemList = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            };
            _gildedRose = new GildedRose(_itemList);
        }

        [Test]
        public void SulfurasLegendaryDosentLoseValue()
        {
            var hand = _itemList.First(x => x.Name == "Sulfuras, Hand of Ragnaros");
            _gildedRose.UpdateQuality();

            Assert.AreEqual(80, hand.Quality);
            Assert.AreEqual(0, hand.SellIn);
        }

        [Test]
        public void AgedBrieQualityImprovesAndLosesValue()
        {
            var brie = _itemList.First(x => x.Name == "Aged Brie");
            _gildedRose.UpdateQuality();


            Assert.AreEqual(1, brie.Quality);
            Assert.AreEqual(1, brie.SellIn);
        }

        [Test]
        public void AgedBrieQualityDoublesWhenSellInIsZero()
        {
            var brie = _itemList.First(x => x.Name == "Aged Brie");
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.AreEqual(4, brie.Quality);
            Assert.AreEqual(-1, brie.SellIn);
        }
    }
}
