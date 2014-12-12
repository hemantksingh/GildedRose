using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.UnitTests
{
	public class GivenSulfuras {

		static String SULFURAS = "Sulfuras, Hand of Ragnaros";
		
		private Item updateFrom(int initialSellIn, int initialQuality) {
			Item item = new Item(SULFURAS, initialSellIn, initialQuality);
			List<Item> items = new List<Item>();
			items.Add(item);
			GildedRose.updateQuality(items);
			return item;
		}

		[Fact]
		public void beforeSellDate() {
			Item item = updateFrom(5, 80);
			Assert.True(item.quality == 80);
			Assert.True(item.sellIn == 5);
		}

		[Fact]
		public void onSellDate() {
			Item item = updateFrom(0, 80);
			Assert.True(item.quality == 80);
			Assert.True(item.sellIn == 0);
		}

		[Fact]
		public void afterSellDate() {
			Item item = updateFrom(-10, 80);
			Assert.True(item.quality == 80);
			Assert.True(item.sellIn == -10);
		}
	}
}
