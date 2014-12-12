using System;
using System.Collections.Generic;
using Xunit;

namespace GuildedRose.UnitTests
{
	public class GivenAConjuredItem 
	{
		static String CONJURED_ITEM = "Conjured Mana Cake";

		private Item updateFrom(int initialSellIn, int initialQuality) {
			Item item = new Item(CONJURED_ITEM, initialSellIn, initialQuality);
			List<Item> items = new List<Item>();
			items.Add(item);
			GildedRose.updateQuality(items);
			return item;
		}

		[Fact]
		public void beforeSellDate() {
			Item item = updateFrom(5, 10);
			Assert.Equal(8, item.quality);
			Assert.Equal(4, item.sellIn);
		}

		[Fact]
		public void beforeSellDateAtZeroQuality() {
			Item item = updateFrom(5, 0);
			Assert.Equal(0, item.quality);
			Assert.Equal(4, item.sellIn);
		}

		[Fact]
		public void onSellDate() {
			Item item = updateFrom(0, 10);
			Assert.Equal(6, item.quality);
			Assert.Equal(-1, item.sellIn);
		}

		[Fact]
		public void onSellDateAtZeroQuality() {
			Item item = updateFrom(0, 0);
			Assert.Equal(0, item.quality);
			Assert.Equal(-1, item.sellIn);
		}

		[Fact]
		public void afterSellDate() {
			Item item = updateFrom(-10, 10);
			Assert.Equal(6, item.quality);
			Assert.Equal(-11, item.sellIn);
		}

		[Fact]
		public void afterSellDateAtZeroQuality() {
			Item item = updateFrom(-10, 0);
			Assert.Equal(0, item.quality);
			Assert.Equal(-11, item.sellIn);
		}
	}
}
