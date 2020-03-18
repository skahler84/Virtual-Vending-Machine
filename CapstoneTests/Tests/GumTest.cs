using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class GumTest
    {
        [TestMethod]
        public void GumConstructorHappyTest()
        {
            Gum gum = new Gum("gum", 1M, "A2", 3);
            string expectedString = "gum";
            string resultString = gum.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "A2";
            resultString = gum.Slot;
            Assert.AreEqual(expectedString, resultString);

            Decimal expectedPrice = 1;
            Decimal resultPrice = gum.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            int expectedInventory = 3;
            int resultInventory = gum.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);

            Gum gum2 = new Gum("More Gum", 234M, "A5", 583858);
            expectedString = "More Gum";
            resultString = gum2.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "A5";
            resultString = gum2.Slot;
            Assert.AreEqual(expectedString, resultString);

            expectedPrice = 234M;
            resultPrice = gum2.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            expectedInventory = 583858;
            resultInventory = gum2.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);
        }
        [TestMethod]
        public void CandyConstructorEdgeTest()
        {
            Gum gum = new Gum("", -34, "", int.MaxValue);
            string expectedString = "";
            string resultString = gum.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "";
            resultString = gum.Slot;
            Assert.AreEqual(expectedString, resultString);

            Decimal expectedPrice = 0;
            Decimal resultPrice = gum.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            int expectedInventory = int.MaxValue;
            int resultInventory = gum.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);

            Gum gum2 = new Gum(null, Decimal.MaxValue, null, -8358);
            expectedString = "Invalid Product Name";
            resultString = gum2.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "Invalid Slot";
            resultString = gum2.Slot;
            Assert.AreEqual(expectedString, resultString);

            expectedPrice = decimal.MaxValue;
            resultPrice = gum2.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            expectedInventory = 0;
            resultInventory = gum2.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);
        }
        [TestMethod]
        public void ProductOutputMessageTest()
        {
            Gum gum = new Gum("Gum", 3M, "A2", 3);
            string expected = "Chew Chew, Yum!";
            string result = gum.ProductOutputMessage();
            Assert.AreEqual(expected, result);
        }

    }
}
