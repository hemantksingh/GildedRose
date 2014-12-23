using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private static readonly Func<int, Func<Item, int>> AdjustQuality = quality => item
                                                  => item.SellIn < 0 ? 2 * quality : quality;

        private static readonly Func<Func<Item, int>, Action<Item>> UpdateProduct
            = adjustQuality => (item =>
                {
                    item.SellIn = item.SellIn - 1;
                    item.Quality = item.Quality + (adjustQuality(item));
                    item.Quality = Math.Min(50, item.Quality);
                    item.Quality = Math.Max(0, item.Quality);
                });        

        private static readonly Func<Item, int> AdjustBackstageQuality = item =>
            {
                if (item.SellIn < 0)
                    return -item.Quality;
                if (item.SellIn < 5)
                    return +3;
                if (item.SellIn < 10)
                    return +2;
                return 1;
            };

        private static readonly Dictionary<string, Action<Item>> Products = new Dictionary<string, Action<Item>>
            {
                {"Aged Brie", UpdateProduct(AdjustQuality(1))},
                {"Backstage passes to a TAFKAL80ETC concert", UpdateProduct(AdjustBackstageQuality)},
                {"Sulfuras, Hand of Ragnaros", item => { }},
                {"NORMAL ITEM", UpdateProduct(AdjustQuality(-1))},
                {"Conjured Mana Cake", UpdateProduct(AdjustQuality(0))}
            };

        public static void UpdateQuality(List<Item> items)
        {
            foreach (Item item in items)
                Products[item.Name](item);
        }
    }
}