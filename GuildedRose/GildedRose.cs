using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildedRose
{
    public class GildedRose
    {
    	public static void updateQuality(List<Item> items) 
    	{
			for (int i = 0; i < items.Count(); i++) 
			{
				if ("Aged Brie" != items[i].Name && "Backstage passes to a TAFKAL80ETC concert" != items[i].Name) 
				{
					if (items[i].Quality > 0) 
					{
						if ("Sulfuras, Hand of Ragnaros" != items[i].Name) 
						{
							items[i].Quality = items[i].Quality - 1;
						}
					}
				} 
				else 
				{
					if (items[i].Quality < 50) 
					{
						items[i].Quality = items[i].Quality + 1;

						if ("Backstage passes to a TAFKAL80ETC concert" == items[i].Name) 
						{
							if (items[i].SellIn < 11) 
							{
								if (items[i].Quality < 50) 
								{
									items[i].Quality = items[i].Quality + 1;
								}
							}

							if (items[i].SellIn < 6) 
							{
								if (items[i].Quality < 50) 
								{
									items[i].Quality = items[i].Quality + 1;
								}
							}
						}
					}
				}

				if ("Sulfuras, Hand of Ragnaros" != items[i].Name) 
				{
					items[i].SellIn = items[i].SellIn - 1;
				}

				if (items[i].SellIn < 0) 
				{
					if ("Aged Brie" != items[i].Name) 
					{
						if ("Backstage passes to a TAFKAL80ETC concert" != items[i].Name) 
						{
							if (items[i].Quality > 0) 
							{
								if ("Sulfuras, Hand of Ragnaros" != items[i].Name) 
								{
									items[i].Quality = items[i].Quality - 1;
								}
							}
						} 
						else 
						{
							items[i].Quality = items[i].Quality - items[i].Quality;
						}
					} else 
					{
						if (items[i].Quality < 50) 
						{
							items[i].Quality =items[i].Quality + 1;
						}
					}
				}
			}
		}
    }
}