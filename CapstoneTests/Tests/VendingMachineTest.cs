using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {        
        [TestMethod]
        public void CreatingListTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            List<string[]> testList = new List<string[]>();
            string[] expected = { "B2", "Cowtales", "1.50", "Candy" };
            testList = vendingMachine.ConvertToListOfArrays();
            string[] result = testList[5];

            CollectionAssert.AreEqual(expected, result);

            string [] expected1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            testList = vendingMachine.ConvertToListOfArrays();
            string [] result1 = testList[0];

            CollectionAssert.AreEqual(expected1, result1);

            string [] expected2 = { "D3", "Chiclets", "0.75", "Gum" };
            testList = vendingMachine.ConvertToListOfArrays();
            string [] result2 = testList[14];

            CollectionAssert.AreEqual(expected2, result2);
        }
        [TestMethod]
        public void GetLogFileLocationTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            string expected = @"C:\Users\Student\workspace\Pairs\csharp-capstone-module-1-team-5\CapstoneTests\bin\Debug\netcoreapp2.1\Log.txt";
            string result = vendingMachine.GetLogFileLocation();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void VendingMachineConstructorTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            decimal expected = 0M;
            decimal result = vendingMachine.Balance;

            Assert.AreEqual(expected, result);

            Dictionary<string, IProduct> expectedDictionary = vendingMachine.InstantiateProductDictionary();
            Dictionary<string, IProduct> resultDictionary = vendingMachine.PopulatedDictionary;
            CollectionAssert.AreEqual(expectedDictionary, resultDictionary);
        }
    }
}
