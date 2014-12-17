using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        public static void UpdateQuality(List<Item> items)
        {
            for (int i = 0; i < items.Count(); i++)
            {
                Item item = items[i];

                int qualityAdjustment = 0;
                switch (item.Name)
                {
                    case "Aged Brie":
                        //new Product().Update(item);
                        item.SellIn = item.SellIn - 1;
                        qualityAdjustment = item.SellIn < 0 ? +2 : +1;
                        item.Quality = item.Quality + qualityAdjustment;

                        item.Quality = Math.Min(50, item.Quality);
                        item.Quality = Math.Max(0, item.Quality);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        item.SellIn = item.SellIn - 1;

                        if (item.SellIn < 0)
                        {
                            qualityAdjustment = -item.Quality;
                        }

                        else if (item.SellIn < 5)
                        {
                            qualityAdjustment = +3;
                        }
                        else if (item.SellIn < 10)
                        {
                            qualityAdjustment = +2;
                        }
                        else
                        {
                            qualityAdjustment = +1;
                        }
                        item.Quality = item.Quality + qualityAdjustment;

                        item.Quality = Math.Min(50, item.Quality);
                        item.Quality = Math.Max(0, item.Quality);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;

                    case "NORMAL ITEM":
                        item.SellIn = item.SellIn - 1;

                        if (item.SellIn < 0)
                            qualityAdjustment = -1;

                        item.Quality = item.Quality + qualityAdjustment;
                        item.Quality = Math.Min(50, item.Quality);
                        item.Quality = Math.Max(0, item.Quality - 1);
                        break;
                    case "Conjured Mana Cake":
                        item.SellIn = item.SellIn - 1;
                        break;
                }
            }
        }
    }
}