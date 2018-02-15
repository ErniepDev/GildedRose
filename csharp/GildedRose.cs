using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                if (IsStandardItem(item.Name))
                {
                    if (item.Quality > 0)
                    {
                        DecrementItemQuality(item, 1);
                    }
                }

                if (IsAgedItem(item.Name) && IsLessThanMaxItemQuality(item.Quality))
                {
                    IncrementIteQuality(item, 1);
                }

                

                    if (IsConcertTicket(item.Name) && IsLessThanMaxItemQuality(item.Quality))
                    {
                        IncrementIteQuality(item, 1);

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && IsLessThanMaxItemQuality(item.Quality))
                        {
                            if (item.SellIn < 11)
                            {
     
                                    IncrementIteQuality(item, 1);
                                
                            }

                            if (item.SellIn < 6)
                            {
                  
                                    IncrementIteQuality(item, 1);
                                
                            }
                        }
                    }
 

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    DecrementItemQuality(item, 1);
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            IncrementIteQuality(item, 1);
                        }
                    }
                }
            }
        }

        private bool IsConcertTicket(string itemName)
        {
            return itemName == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsAgedItem(string itemName)
        {
            return itemName == "Aged Brie";
        }

        private bool IsStandardItem(string itemName)
        {
            return itemName != "Aged Brie" && itemName != "Backstage passes to a TAFKAL80ETC concert" &&
                   itemName != "Sulfuras, Hand of Ragnaros";
        }

        private void IncrementIteQuality(Item item, int incrementAmount)
        {
            UpdateItemQuality(item, incrementAmount);
        }

        private void DecrementItemQuality(Item item, int decrementAmount)
        {
            UpdateItemQuality(item, -decrementAmount);
        }

        private void UpdateItemQuality(Item item, int qualityChangeAmount)
        {
            item.Quality += qualityChangeAmount;
        }

        private bool IsLessThanMaxItemQuality(int itemQuality)
        {
            return itemQuality < 50;
        }
    }
}
