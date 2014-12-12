using System;

namespace GildedRose
{
	public class Item 
	{
	    public String name;
		public int sellIn; 
	    public int quality; 
	    
	    public Item(String name, int sellIn, int quality) 
	    {
			this.Name = name;
			this.SellIn = sellIn;
			this.Quality = quality;
		}
	    
	    public String Name 
	    { 
	    	set
	    	{
    			name = value;
	    	} 
	    	get
	    	{
	    		return name;
	    	} 
	    }

	    public int SellIn 
	    { 
	    	set
	    	{
    			sellIn = value;
	    	} 
	    	get
	    	{
	    		return sellIn;
	    	} 
	    }

	    public int Quality 
	    { 
	    	set
	    	{
    			quality = value;
	    	} 
	    	get
	    	{
	    		return quality;
	    	} 
	    }

	}
}
