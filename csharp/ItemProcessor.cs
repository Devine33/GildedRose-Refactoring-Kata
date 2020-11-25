using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class ItemProcessor
    {
        public ItemProcessor Create(string name)
        {
            switch (name)
            {
                case "Aged Brie":
                    return new AgedBrieProcessor();
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassProcessor();
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasProcessor() ;
                default:
                    return new NormalItemProcessor();
            }
        }

        public virtual void UpdateItems(Item item){}
    }
}
