namespace csharp
{
    class AgedBrieProcessor : ItemProcessor
    {
        public override void UpdateItems(Item item)
        {
            var isConjured = item.Name.Contains("Conjured");
            var degradingValue = isConjured ? 2 : 1;


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
    }
}