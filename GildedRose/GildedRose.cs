using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private static readonly Func<int, Func<Item, int>> AdjustQuality = quality => item
                                                  => item.SellIn < 0 ? 2 * quality : quality;

        private static readonly Func<Func<Item, int>, IProduct> CreateProduct =
            adjustQuality => new Product(adjustQuality);

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

        static readonly Dictionary<string, IProduct> Products = new Dictionary<string, IProduct>
            {
                {"Aged Brie", CreateProduct(AdjustQuality(1))},
                {"Backstage passes to a TAFKAL80ETC concert", CreateProduct(AdjustBackstageQuality)},
                {"Sulfuras, Hand of Ragnaros", new SulfurasProduct()},
                {"NORMAL ITEM", CreateProduct(AdjustQuality(-1))},
                {"Conjured Mana Cake", CreateProduct(AdjustQuality(0))}
            };

        public static void UpdateQuality(List<Item> items)
        {
            foreach (Item item in items)
                Products[item.Name].Update(item);
        }
       
    }

    internal class SulfurasProduct : IProduct
    {
        public void Update(Item item)
        {
        }
    }


    public interface IProduct
    {
        void Update(Item item);
    }

    public class Product : IProduct
    {
        private readonly Func<Item,  int> _adjustQuality;

        public Product(Func<Item, int> adjustQuality)
        {
            _adjustQuality = adjustQuality;
        }

        public void Update(Item item)
        {
            item.SellIn = item.SellIn - 1;
            item.Quality = item.Quality + (_adjustQuality(item));

            item.Quality = Math.Min(50, item.Quality);
            item.Quality = Math.Max(0, item.Quality);
        }
    }
}