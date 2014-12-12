using System;
using System.Collections.Generic;
using Xunit;

namespace GuildedRose.UnitTests
{
	public class GivenANormalItem 
	{
		static String NORMAL_ITEM = "NORMAL ITEM";
		
		private Item updateFrom(int initialSellIn, int initialQuality) {
			Item item = new Item(NORMAL_ITEM, initialSellIn, initialQuality);
			List<Item> items = new List<Item>();
			items.Add(item);
			GildedRose.updateQuality(items);
			return item;
		}

		[Fact]
		public void beforeSellDate() {
			Item item = updateFrom(5, 10);
			Assert.True(item.quality == 9);
			Assert.True(item.sellIn == 4);
		}

		[Fact]
		public void onSellDate() {
			Item item = updateFrom(0, 10);
			Assert.True(item.quality == 8);
			Assert.True(item.sellIn == -1);
		}

		[Fact]
		public void afterSellDate() {
			Item item = updateFrom(-10, 10);
			Assert.True(item.quality == 8);
			Assert.True(item.sellIn == -11);
		}

		[Fact]
		public void ofZeroQuality() {
			Item item = updateFrom(5, 0);
			Assert.True(item.quality == 0);
		}
	}
}
