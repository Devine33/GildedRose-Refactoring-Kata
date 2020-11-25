namespace csharp
{
    public class NormalItemProcessor : ItemProcessor
    {
        public override void UpdateItems(Item item)
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