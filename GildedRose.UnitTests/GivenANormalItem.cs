using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.UnitTests
{
	public class GivenANormalItem 
	{
		static String NORMAL_ITEM = "NORMAL ITEM";
		
		private Item UpdateFrom(int initialSellIn, int initialQuality) 
		{
			Item item = new Item(NORMAL_ITEM, initialSellIn, initialQuality);
			List<Item> items = new List<Item>();
			items.Add(item);
			GildedRose.UpdateQuality(items);
			return item;
		}

		[Fact]
		public void BeforeSellDate() 
		{
			Item item = UpdateFrom(5, 10);
			Assert.True(item.quality == 9);
			Assert.True(item.sellIn == 4);
		}

		[Fact]
		public void OnSellDate() 
		{
			Item item = UpdateFrom(0, 10);
			Assert.True(item.quality == 8);
			Assert.True(item.sellIn == -1);
		}

		[Fact]
		public void AfterSellDate() 
		{
			Item item = UpdateFrom(-10, 10);
			Assert.True(item.quality == 8);
			Assert.True(item.sellIn == -11);
		}

		[Fact]
		public void OfZeroQuality() 
		{
			Item item = UpdateFrom(5, 0);
			Assert.True(item.quality == 0);
		}
	}
}
