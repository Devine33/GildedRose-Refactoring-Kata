using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var  currentItem = item.Create(item.Name, item.Quality, item.SellIn);
                currentItem.UpdateItems(item);
            }
        }
    }
}