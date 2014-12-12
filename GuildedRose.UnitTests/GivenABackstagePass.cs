using System;
using System.Collections.Generic;
using Xunit;

namespace GuildedRose.UnitTests
{
	public class GivenABackstagePass 
	{
		static String BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";
		
		private Item UpdateFrom(int initialSellIn, int initialQuality) {
			Item item = new Item(BACKSTAGE_PASS, initialSellIn, initialQuality);
			List<Item> items = new List<Item>();
			items.Add(item);
			GildedRose.updateQuality(items);
			return item;
		}

		[Fact]
		public void longBeforeSellDate() 
		{
			Item item = UpdateFrom(11, 10);
			Assert.True(item.quality == 11);
			Assert.True(item.sellIn == 10);
		}

		[Fact]
		public void longBeforeSellDateAtMaxQuality() 
		{
			Item item = UpdateFrom(11, 50);
			Assert.True(item.quality == 50);
			Assert.True(item.sellIn == 10);
		}

		[Fact]
		public void mediumCloseSellDateUpperBound() 
		{
			Item item = UpdateFrom(10, 10);
			Assert.True(item.quality == 12);
			Assert.True(item.sellIn == 9);
		}

		[Fact]
		public void mediumCloseSellDateUpperBoundAtMaxQuality() 
		{
			Item item = UpdateFrom(10, 50);
			Assert.True(item.quality == 50);
			Assert.True(item.sellIn == 9);
		}

		[Fact]
		public void mediumCloseSellDateLowerBound() 
		{
			Item item = UpdateFrom(6, 10);
			Assert.True(item.quality == 12);
			Assert.True(item.sellIn == 5);
		}

		[Fact]
		public void mediumCloseSellDateLowerBoundAtMaxQuality() 
		{
			Item item = UpdateFrom(6, 50);
			Assert.True(item.quality == 50);
			Assert.True(item.sellIn == 5);
		}

		[Fact]
		public void veryCloseToSellDateUpperBound() 
		{
			Item item = UpdateFrom(5, 10);
			Assert.True(item.quality == 13);
			Assert.True(item.sellIn == 4);
		}

		[Fact]
		public void veryCloseToSellDateUpperBoundAtMaxQuality() 
		{
			Item item = UpdateFrom(5, 50);
			Assert.True(item.quality == 50);
			Assert.True(item.sellIn == 4);
		}

		[Fact]
		public void veryCloseToSellDateLowerBound() 
		{
			Item item = UpdateFrom(1, 10);
			Assert.True(item.quality == 13);
			Assert.True(item.sellIn == 0);
		}

		[Fact]
		public void veryCloseToSellDateLowerBoundAtMaxQuality() 
		{
			Item item = UpdateFrom(1, 50);
			Assert.True(item.quality == 50);
			Assert.True(item.sellIn == 0);
		}

		[Fact]
		public void onSellDate() 
		{
			Item item = UpdateFrom(0, 10);
			Assert.True(item.quality == 0);
			Assert.True(item.sellIn == -1);
		}

		[Fact]
		public void afterSellDate() 
		{
			Item item = UpdateFrom(-10, 10);
			Assert.True(item.quality == 0);
			Assert.True(item.sellIn == -11);
		}
	}
}
