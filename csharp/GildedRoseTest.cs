using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace csharp
{
    [TestClass]
    public class GildedRoseTest
    {
        [TestMethod]
        public void ShouldDecrementQualityForStandardItem()
        {
            List<Item> standardItems = new List<Item> {new Item {Name = "Lol Sword", Quality = 5, SellIn = 10}};
            GildedRose gildedRose = new GildedRose(standardItems);

            gildedRose.UpdateQuality();

            standardItems[0].Quality.Should().Be(4);
        }

        [TestMethod]
        public void ShouldDecrementSellByForStandardItem()
        {
            List<Item> standardItems = new List<Item> { new Item { Name = "Lol Sword", Quality = 5, SellIn = 10 } };
            GildedRose gildedRose = new GildedRose(standardItems);

            gildedRose.UpdateQuality();

            standardItems[0].SellIn.Should().Be(9);
        }

        [TestMethod]
        public void ShouldNotDecrementLegendary()
        {
            List<Item> standardItems = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 } };
            GildedRose gildedRose = new GildedRose(standardItems);

            gildedRose.UpdateQuality();

            standardItems[0].Quality.Should().Be(80);
            standardItems[0].SellIn.Should().Be(0);
        }

        [TestMethod]
        public void ShouldDecrementAgedBrieSellByByOne() //ShouldIncrementAgedBrieByOneWhneMoreThanTenDaysLeftToSellBy
        {
            List<Item> standardItems = new List<Item> { new Item { Name = "Aged Brie", Quality = 0, SellIn = 11 } };
            GildedRose gildedRose = new GildedRose(standardItems);

            gildedRose.UpdateQuality();

            standardItems[0].SellIn.Should().Be(10);
        }

        [TestMethod]
        public void ShouldIncrementAgedBrieQualityByOneWhneMoreThanTenDaysLeftToSellBy() //ShouldIncrementAgedBrieByOneWhneMoreThanTenDaysLeftToSellBy
        {
            List<Item> standardItems = new List<Item> { new Item { Name = "Aged Brie", Quality = 0, SellIn = 11 } };
            GildedRose gildedRose = new GildedRose(standardItems);

            gildedRose.UpdateQuality();

            standardItems[0].Quality.Should().Be(1);
            standardItems[0].SellIn.Should().Be(10);
        }

        [TestMethod]
        public void ShouldIncrementConcertTicketsQualityByOneWhenMoreThan10DaysLeftToSellBy() //ShouldIncrementAgedBrieByOneWhneMoreThanTenDaysLeftToSellBy
        {
            List<Item> standardItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 2, SellIn = 11 } };
            GildedRose gildedRose = new GildedRose(standardItems);

            gildedRose.UpdateQuality();

            standardItems[0].Quality.Should().Be(3);
            standardItems[0].SellIn.Should().Be(10);
        }


        [TestMethod]
        public void ShouldIncrementConcertTicketsQualityByTwoWhneLessThan11DaysToSellBy()
        {
            List<Item> standardItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 5, SellIn = 10 } };
            GildedRose gildedRose = new GildedRose(standardItems);

            gildedRose.UpdateQuality();

            standardItems[0].Quality.Should().Be(7);
            standardItems[0].SellIn.Should().Be(9);
        }

        [TestMethod]
        public void ShouldIncrementConcertTicketsQualityByFiveWhneLessThan6DaysToSellBy() 
        {
            List<Item> standardItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 5, SellIn = 5 } };
            GildedRose gildedRose = new GildedRose(standardItems);

            gildedRose.UpdateQuality();

            standardItems[0].Quality.Should().Be(8);
            standardItems[0].SellIn.Should().Be(4);
        }

        [TestMethod]
        public void ShouldNeverExceedItemQualityOf50ForAllNonLegendaryItems()
        {
            List<Item> standardItems = new List<Item> { new Item { Name = "Aged Brie", Quality = 5, SellIn = 5 } };
            GildedRose gildedRose = new GildedRose(standardItems);

            for (int i = 0; i < 60; i++)
            {
                gildedRose.UpdateQuality();
            }          

            standardItems[0].Quality.Should().Be(50);
        }
    }
}
