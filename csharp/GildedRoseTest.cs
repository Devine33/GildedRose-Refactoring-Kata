using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private GildedRose _gildedRose;
        private IList<Item> _itemList;
        private const string Vest = "+5 Dexterity Vest";
        private const string Brie = "Aged Brie";
        private const string Elixir = "Elixir of the Mongoose";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        [SetUp]
        public void Setup()
        {
            _itemList = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 7},
                new Item {Name = "Elixir of the Mongoose", SellIn = 3, Quality = 50},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 10
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 10
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 10
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 2,
                    Quality = 50
                },
            };
            _gildedRose = new GildedRose(_itemList);
        }

        [Test]
        public void SulfurasLegendaryDosentLoseValue()
        {
            var hand = _itemList.First(x => x.Name == Sulfuras);
            _gildedRose.UpdateQuality();

            Assert.AreEqual(80, hand.Quality);
            Assert.AreEqual(0, hand.SellIn);
        }

        [Test]
        public void ItemQualityDegradesTwiceAsFast()
        {
            var elixir = _itemList.First(x => x.Name == Elixir && x.SellIn == 0);
            _gildedRose.UpdateQuality();

            Assert.AreEqual(5, elixir.Quality);
            Assert.AreEqual(-1, elixir.SellIn);
        }

        [Test]
        public void AgedBrieQualityImprovesAndLosesValue()
        {
            var brie = _itemList.First(x => x.Name == Brie);
            _gildedRose.UpdateQuality();


            Assert.AreEqual(1, brie.Quality);
            Assert.AreEqual(1, brie.SellIn);
        }

        [Test]
        public void AgedBrieQualityDoublesWhenSellInIsZero()
        {
            var brie = _itemList.First(x => x.Name == Brie);
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.AreEqual(4, brie.Quality);
            Assert.AreEqual(-1, brie.SellIn);
        }

        [Test]
        public void QualityIsNeverNegative()
        {
            var vest = _itemList.First(x => x.Name == Vest && x.Quality == 0);
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.LessOrEqual(-1, vest.Quality);
        }

        [Test]
        public void QualityDoesntExceedLimitOf50()
        {
            var pass = _itemList.First(x => x.Name == Backstage && x.Quality == 50);
            _gildedRose.UpdateQuality();
            Assert.AreEqual(50,pass.Quality);
        }

        [Test]
        public void BackstagePassQualityIncreasesByTwoWhen10DaysOrLess()
        {
            var pass = _itemList.First(x => x.Name == Backstage && x.Quality == 10 && x.SellIn == 10);
            _gildedRose.UpdateQuality();
            Assert.AreEqual(12, pass.Quality);
        }

        [Test]
        public void BackstagePassQualityIncreasesByThreeWhen5DaysOrLess()
        {
            var pass = _itemList.First(x => x.Name == Backstage && x.Quality == 10 && x.SellIn == 5);
            _gildedRose.UpdateQuality();
            Assert.AreEqual(13, pass.Quality);
        }

        [Test]
        public void BackstagePassQualityDropsToZeroAfterConcert()
        {
            var pass = _itemList.First(x => x.Name == Backstage && x.Quality == 10 && x.SellIn == 0);
            _gildedRose.UpdateQuality();
            Assert.AreEqual(0, pass.Quality);
        }



    }
}
