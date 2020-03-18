using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CandyTest
    {
        [TestMethod]
        public void CandyConstructorHappyTest()
        {
            Candy candy = new Candy("candy",1M,"A2",3);
            string expectedString = "candy";
            string resultString = candy.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "A2";
            resultString = candy.Slot;
            Assert.AreEqual(expectedString, resultString);

            Decimal expectedPrice = 1;
            Decimal resultPrice = candy.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            int expectedInventory = 3;
            int resultInventory = candy.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);

            Candy candy2 = new Candy("More Candy", 234M, "A5", 583858);
            expectedString = "More Candy";
            resultString = candy2.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "A5";
            resultString = candy2.Slot;
            Assert.AreEqual(expectedString, resultString);

            expectedPrice = 234M;
            resultPrice = candy2.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            expectedInventory = 583858;
            resultInventory = candy2.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);
        }
        [TestMethod]        
        public void CandyConstructorEdgeTest()
        {
            Candy candy = new Candy("", -34, "", int.MaxValue);
            string expectedString = "";
            string resultString = candy.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "";
            resultString = candy.Slot;
            Assert.AreEqual(expectedString, resultString);

            Decimal expectedPrice = 0;
            Decimal resultPrice = candy.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            int expectedInventory = int.MaxValue;
            int resultInventory = candy.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);

            Candy candy2 = new Candy(null, Decimal.MaxValue, null, -8358);
            expectedString = "Invalid Product Name";
            resultString = candy2.Name;
            Assert.AreEqual(expectedString, resultString);

            expectedString = "Invalid Slot";
            resultString = candy2.Slot;
            Assert.AreEqual(expectedString, resultString);

            expectedPrice = decimal.MaxValue;
            resultPrice = candy2.Price;
            Assert.AreEqual(expectedPrice, resultPrice);

            expectedInventory = 0;
            resultInventory = candy2.InventoryCount;
            Assert.AreEqual(expectedInventory, resultInventory);
        }
        [TestMethod]
        public void ProductOutputMessageTest()
        {
            Candy candy = new Candy("Candy", 3M, "A2", 3);
            string expected = "Munch Munch, Yum!";
            string result = candy.ProductOutputMessage();
            Assert.AreEqual(expected, result);
        }

    }
}
