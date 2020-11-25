using System.Data;

namespace csharp
{
    class BackstagePass : Item
    {
        public BackstagePass()
        {
        }

        public override void UpdateItems(Item item)
        {
            var isConjured = item.Name.Contains("Conjured");
            var degradingValue = 1;
            if (isConjured)
            {
                degradingValue = 2;
            }

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
        }
    }
}