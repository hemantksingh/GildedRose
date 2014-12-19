using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private static readonly Dictionary<string, IProduct> Products = new Dictionary<string, IProduct>
            {
                {"Aged Brie", new Product(new AgedBrieQualityAdjuster(2))},
                {"Backstage passes to a TAFKAL80ETC concert", new Product(new BackstageQualityAdjuster(1))},
                {"Sulfuras, Hand of Ragnaros", new SulfurasProduct()},
                {"NORMAL ITEM", new Product(new NormalQualityAdjuster(-1))},
                {"Conjured Mana Cake", new Product(new ConjuredQualityAdjuster(0))}
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

    public class ConjuredQualityAdjuster : IAdjustQuality
    {
        private readonly int _defaultQuality;

        public ConjuredQualityAdjuster(int defaultQuality)
        {
            _defaultQuality = defaultQuality;
        }

        public int Adjust(Item item)
        {
            return _defaultQuality;
        }
    }

    public class NormalQualityAdjuster : IAdjustQuality
    {
        private readonly int _defaultQuality;

        public NormalQualityAdjuster(int defaultQuality)
        {
            _defaultQuality = defaultQuality;
        }

        public int Adjust(Item item)
        {
            return item.SellIn < 0 ? -2 : _defaultQuality;
        }
    }

    public class BackstageQualityAdjuster : IAdjustQuality
    {
        private readonly int _defaultQuality;

        public BackstageQualityAdjuster(int defaultQuality)
        {
            _defaultQuality = defaultQuality;
        }

        public int Adjust(Item item)
        {
            if (item.SellIn < 0)
                return -item.Quality;
            if (item.SellIn < 5)
                return +3;
            if (item.SellIn < 10)
                return +2;

            return _defaultQuality;
        }
    }

    public interface IAdjustQuality
    {
        int Adjust(Item item);
    }

    public class AgedBrieQualityAdjuster : IAdjustQuality
    {
        private readonly int _qualityAdjuster;

        public AgedBrieQualityAdjuster(int qualityAdjuster)
        {
            _qualityAdjuster = qualityAdjuster;
        }

        public int Adjust(Item item)
        {
            return item.SellIn < 0 ? _qualityAdjuster : +1;
        }
    }

    public interface IProduct
    {
        void Update(Item item);
    }

    public class Product : IProduct
    {
        private readonly IAdjustQuality _qualityAdjuster;

        public Product(IAdjustQuality qualityAdjuster)
        {
            _qualityAdjuster = qualityAdjuster;
        }

        public void Update(Item item)
        {
            item.SellIn = item.SellIn - 1;
            item.Quality = item.Quality + (_qualityAdjuster.Adjust(item));

            item.Quality = Math.Min(50, item.Quality);
            item.Quality = Math.Max(0, item.Quality);
        }
    }
}