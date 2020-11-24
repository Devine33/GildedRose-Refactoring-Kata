using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItems(item);
            }
        }

        private static void UpdateItems(Item item)
        {
            var isConjured = item.Name.Contains("Conjured");
            var degradingValue = 1;
            if (isConjured)
            {
                degradingValue = 2;
            }

            if (item.Name == "Aged Brie")
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }

                item.SellIn -= degradingValue;


                if (item.SellIn < 0)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }
            else
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality -= degradingValue;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn -= degradingValue;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality -= degradingValue;
                            }
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
            }
        }
    }
}