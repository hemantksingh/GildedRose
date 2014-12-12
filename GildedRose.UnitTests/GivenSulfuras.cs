using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.UnitTests
{
	public class GivenSulfuras {

		static String SULFURAS = "Sulfuras, Hand of Ragnaros";
		
		private Item UpdateFrom(int initialSellIn, int initialQuality) 
		{
			Item item = new Item(SULFURAS, initialSellIn, initialQuality);
			List<Item> items = new List<Item>();
			items.Add(item);
			GildedRose.UpdateQuality(items);
			return item;
		}

		[Fact]
		public void BeforeSellDate() 
		{
			Item item = UpdateFrom(5, 80);
			Assert.True(item.quality == 80);
			Assert.True(item.sellIn == 5);
		}

		[Fact]
		public void OnSellDate() 
		{
			Item item = UpdateFrom(0, 80);
			Assert.True(item.quality == 80);
			Assert.True(item.sellIn == 0);
		}

		[Fact]
		public void AfterSellDate() 
		{
			Item item = UpdateFrom(-10, 80);
			Assert.True(item.quality == 80);
			Assert.True(item.sellIn == -10);
		}
	}
}
