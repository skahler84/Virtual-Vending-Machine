using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class DrinkTest
    {
        [TestMethod]
        public void DrinkConstructorHappyTest()
        {
            Drink drink = new Drink("drink", 1M, "A2", 3);
            string expectedString = "drink";
            string resultString = drink.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "A2";
            resultString = drink.Slot;
            Assert.AreEqual(expectedString, resultString);

            Decimal expectedPrice = 1;
            Decimal resultPrice = drink.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            int expectedInventory = 3;
            int resultInventory = drink.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);

            Drink drink2 = new Drink("More Drink", 234M, "A5", 583858);
            expectedString = "More Drink";
            resultString = drink2.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "A5";
            resultString = drink2.Slot;
            Assert.AreEqual(expectedString, resultString);

            expectedPrice = 234M;
            resultPrice = drink2.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            expectedInventory = 583858;
            resultInventory = drink2.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);
        }
        [TestMethod]
        public void DrinkConstructorEdgeTest()
        {
            Drink drink = new Drink("", -34, "", int.MaxValue);
            string expectedString = "";
            string resultString = drink.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "";
            resultString = drink.Slot;
            Assert.AreEqual(expectedString, resultString);

            Decimal expectedPrice = 0;
            Decimal resultPrice = drink.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            int expectedInventory = int.MaxValue;
            int resultInventory = drink.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);

            Drink drink2 = new Drink(null, Decimal.MaxValue, null, -8358);
            expectedString = "Invalid Product Name";
            resultString = drink2.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "Invalid Slot";
            resultString = drink2.Slot;
            Assert.AreEqual(expectedString, resultString);

            expectedPrice = decimal.MaxValue;
            resultPrice = drink2.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            expectedInventory = 0;
            resultInventory = drink2.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);
        }
        [TestMethod]
        public void ProductOutputMessageTest()
        {
            Drink drink = new Drink("Drink", 3M, "A2", 3);
            string expected = "Glug Glug, Yum!";
            string result = drink.ProductOutputMessage();
            Assert.AreEqual(expected, result);
        }

    }
}
