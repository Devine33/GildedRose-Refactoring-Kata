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
            var processor = new ItemProcessor();
            foreach (var item in _items)
            {
                var currentItem = processor.Create(item.Name);
                currentItem.UpdateItems(item);
            }
        }
    }
}