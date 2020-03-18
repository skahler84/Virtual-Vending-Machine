using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ChipsTest
    {
        [TestMethod]
        public void ChipsConstructorHappyTest()
        {
            Chips chips = new Chips("chip", 1M, "A2", 3);
            string expectedString = "chip";
            string resultString = chips.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "A2";
            resultString = chips.Slot;
            Assert.AreEqual(expectedString, resultString);

            Decimal expectedPrice = 1;
            Decimal resultPrice = chips.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            int expectedInventory = 3;
            int resultInventory = chips.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);

            Chips chips2 = new Chips("More Chips", 234M, "A5", 583858);
            expectedString = "More Chips";
            resultString = chips2.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "A5";
            resultString = chips2.Slot;
            Assert.AreEqual(expectedString, resultString);

            expectedPrice = 234M;
            resultPrice = chips2.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            expectedInventory = 583858;
            resultInventory = chips2.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);
        }
        [TestMethod]
        public void ChipsConstructorEdgeTest()
        {
            Chips chips = new Chips("", -34, "", int.MaxValue);
            string expectedString = "";
            string resultString = chips.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "";
            resultString = chips.Slot;
            Assert.AreEqual(expectedString, resultString);

            Decimal expectedPrice = 0;
            Decimal resultPrice = chips.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            int expectedInventory = int.MaxValue;
            int resultInventory = chips.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);

            Chips chips2 = new Chips(null, Decimal.MaxValue, null, -8358);
            expectedString = "Invalid Product Name";
            resultString = chips2.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "Invalid Slot";
            resultString = chips2.Slot;
            Assert.AreEqual(expectedString, resultString);

            expectedPrice = decimal.MaxValue;
            resultPrice = chips2.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            expectedInventory = 0;
            resultInventory = chips2.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);
        }
        [TestMethod]
        public void ProductOutputMessageTest()
        {
            Chips chips = new Chips("Chips", 3M, "A2", 3);
            string expected = "Crunch Crunch, Yum!";
            string result = chips.ProductOutputMessage();
            Assert.AreEqual(expected, result);
        }

    }
}