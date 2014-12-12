using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.UnitTests
{
	public class GivenAgedBrie {

		static String AGED_BRIE = "Aged Brie";
		
		private Item updateFrom(int initialSellIn, int initialQuality) 
		{
			Item item = new Item(AGED_BRIE, initialSellIn, initialQuality);
			List<Item> items = new List<Item>();
			items.Add(item);
			GildedRose.UpdateQuality(items);
			return item;
		}

		[Fact]
		public void BeforeSellDate() 
		{
			Item item = updateFrom(5, 10);
			Assert.True(item.quality == 11);
			Assert.True(item.sellIn == 4);
		}
		
		[Fact]
		public void BeforeSellDateWithMaxQuality() 
		{
			Item item = updateFrom(5, 50);
			Assert.True(item.quality == 50);
			Assert.True(item.sellIn == 4);
		}

		[Fact]
		public void OnSellDate() 
		{
			Item item = updateFrom(0, 10);
			Assert.True(item.quality == 12);
			Assert.True(item.sellIn == -1);
		}

		[Fact]
		public void OnSellDateWithMaxQuality() 
		{
			Item item = updateFrom(0, 50);
			Assert.True(item.quality == 50);
			Assert.True(item.sellIn == -1);
		}

		[Fact]
		public void AfterSellDate() 
		{
			Item item = updateFrom(-10, 10);
			Assert.True(item.quality == 12);
			Assert.True(item.sellIn == -11);
		}

		[Fact]
		public void AfterSellDateWithMaxQuality() 
		{
			Item item = updateFrom(-10, 50);
			Assert.True(item.quality == 50);
			Assert.True(item.sellIn == -11);
		}
	}
}
