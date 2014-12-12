using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.UnitTests
{
	public class GivenSeveralItems {

		private List<Item> items = new List<Item>();

		public GivenSeveralItems () 
		{
			items.Add(new Item("NORMAL ITEM", 5, 10));
			items.Add(new Item("Aged Brie", 3, 10));
		}

		[Fact]
		public void test() {
			GildedRose.updateQuality(items);

			Assert.Equal(9, items[0].quality);
			Assert.Equal(4, items[0].sellIn);
			Assert.Equal(11, items[1].quality);
			Assert.Equal(2, items[1].sellIn);
		}
	}
}