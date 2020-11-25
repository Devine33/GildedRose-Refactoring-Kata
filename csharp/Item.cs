using System.Linq;

namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }

        public Item Create(string name, int quality, int sellIn)
        {
            switch (name)
            {
                case "Aged Brie":
                    return new AgedBrie() {Name = name, Quality = quality, SellIn = sellIn};
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePass() {Name = name, Quality = quality, SellIn = sellIn};
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras() {Name = name, Quality = quality, SellIn = sellIn};
                default:
                    return new Item() {Name = name, Quality = quality, SellIn = sellIn};
            }
        }

        public virtual void UpdateItems(Item item)
        {
            var isConjured = item.Name.Contains("Conjured");
            var degradingValue = 1;
            if (isConjured)
            {
                degradingValue = 2;
            }

            if (item.Quality > 0)
            {
                item.Quality -= degradingValue;
            }

            item.SellIn -= degradingValue;


            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= degradingValue;
                }
            }
        }
    }
}