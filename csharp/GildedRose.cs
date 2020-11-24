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

            switch (item.Name)
            {
                case "Aged Brie":
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

                    break;
                }
                case "Backstage passes to a TAFKAL80ETC concert":
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
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


                    item.SellIn -= degradingValue;

                    if (item.SellIn < 0)
                    {
                        item.Quality -= item.Quality;
                    }

                    break;
                }
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                {
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

                    break;
                }
            }
        }
    }
}