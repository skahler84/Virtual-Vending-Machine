using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        /// <summary>
        ///creates balance amount for the log.txt file 
        /// </summary>
        public decimal MakeChangeLogBalance { get; private set; }
        /// <summary>
        /// Finishes the purchase for the customer (gives change in smallest amount of coins andsets machine balance to 0, returns user to main menu)
        /// </summary>
        /// <returns>True if purchase successfully completes</returns>
        public bool FinishPurchase()
        {
            bool isFinished = false;
            int numberOfQuarters;
            int numberOfDimes;
            int numberOfNickels;
            //Calculation to return fewest coins possible (multiply by 100 so can use integer math and modulus to determine coin amounts)
            int balanceForChange = Convert.ToInt32(Balance * 100);
            MakeChangeLogBalance = Balance;
            numberOfQuarters = balanceForChange / 25;
            balanceForChange = balanceForChange % 25;
            numberOfDimes = balanceForChange / 10;
            balanceForChange = balanceForChange % 10;
            numberOfNickels = balanceForChange / 5;
            Console.WriteLine($"Your change is {Balance:C2}. Giving you {numberOfQuarters} Quarters, {numberOfDimes} Dimes, and {numberOfNickels} Nickels");
            Balance = 0;
            WriteReturnChangeToLog();
            isFinished = true;
            return isFinished;
        }
        /// <summary>
        /// Combines the directory and file name of the sales audit log to be created and combines them into a full path 
        /// </summary>
        /// <returns>Fully Qualified Path of the audit log file</returns>
        public string GetLogFileLocation()
        {
            string directory = Directory.GetCurrentDirectory();
            string filename = "Log.txt";
            string fullPath = Path.Combine(directory, filename);
            return fullPath;            
        }
        /// <summary>
        /// Writes a blank line in the exit log between uses of the vending machine to help with readability
        /// </summary>
        /// <returns>True if blank line is successfully written, false otherwise</returns>
        
        public bool WriteToLog(string line)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetLogFileLocation(),true))
                {
                    sw.WriteLine(line);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something has gone wrong. Log line not written.");
                return false;
            }
        }
        /// <summary>
        /// Writes blank line to log on exit
        /// </summary>
        /// <returns>True if line written, false otherwise</returns>
        public bool WriteBlankLineOnExitToLog()
        {
            return WriteToLog("");       
        }
        /// <summary>
        /// Writes the current day/time, amount of money deposited, and the current balance to the log
        /// </summary>
        /// <returns>True if successfully written, false otherwise</returns>
        public bool WriteFeedMoneyToLog()
        {
            return WriteToLog($">{DateTime.UtcNow} FEED MONEY: {DepositedAmount:C2} {Balance:C2}");            
        }
        /// <summary>
        /// Writes the current day/time, item purchased, what the original balance was, and what the new balance is after the purchase to the log
        /// </summary>
        /// <returns>True if successfully written, false otherwise</returns>
        public bool WritePurchaseItemToLog()
        {
            return WriteToLog($">{DateTime.UtcNow} {PurchasedItem.Name} {PurchasedItem.Slot} {Balance:C2} {(Balance - PurchasedItem.Price):C2}");            
        }
        /// <summary>
        /// Writes the current day/time, the amount of change to be given, and the balance after the changes is given
        /// </summary>
        /// <returns>True if successfully written, False otherwise</returns>
        public bool WriteReturnChangeToLog()
        {
            return WriteToLog($">{DateTime.UtcNow} GIVE CHANGE: {MakeChangeLogBalance:C2} {Balance:C2}");            
        }
        /// <summary>
        /// The item selected by the user for purchase from the vending machine
        /// </summary>
        public IProduct PurchasedItem { get; private set; }
        /// <summary>
        /// Purchases item from vending machine by selecting it via user input, decrements inventory by 1, and updates user balance by subtracting the item price.
        /// </summary>
        /// <returns>True if purchase was made, false if not</returns>
        public bool MakePurchase()
        {
            bool successfulPurchase = false;
            bool stillPurchasing = true;
            //while loop bool set to true initially, we make it false if want to return the customer back to the menu
            while (stillPurchasing)
            {
                Console.WriteLine("Please enter the slot of the item you want to purchase");
                try
                {
                    //Convert customer input to upper case to match text file and check if input matches a slot
                    string inputSlot = Console.ReadLine().ToUpper();
                    if (PopulatedDictionary.ContainsKey(inputSlot))
                    {
                        //If statement to notify customer if product is sold out
                        if (PopulatedDictionary[inputSlot].InventoryCount == 0) 
                        {                           
                            Console.WriteLine("Sorry, the product is sold out");
                            Console.WriteLine();
                        } else
                        {
                            //If statement that handles purchase based on customer inputs (selects item, decrements amount, informs user of cost and how much money they have left)
                            if (Balance >= PopulatedDictionary[inputSlot].Price)
                            {
                                PurchasedItem = PopulatedDictionary[inputSlot];
                                PurchasedItem.InventoryCount -= 1;                                
                                Console.Clear();
                                Console.WriteLine(PopulatedDictionary[inputSlot].ProductOutputMessage());
                                WritePurchaseItemToLog();
                                Balance -= PopulatedDictionary[inputSlot].Price;                                
                                Console.WriteLine($"You selected {PopulatedDictionary[inputSlot].Name}. Costs: {PopulatedDictionary[inputSlot].Price:C2}. You have {Balance:C2} remaining.");
                                Console.WriteLine();
                                stillPurchasing = false;
                                successfulPurchase = true;
                            }
                            //Else statement informs customer if they don't have enough money to buy the selected item
                            else
                            {                                
                                Console.Clear();
                                Console.WriteLine("You don't have enough money.");
                                stillPurchasing = false;
                            }
                        }
                    } 
                    //Else statement informs customer if they entered an invalid slot 
                    else
                    {
                        Console.WriteLine("That was an invalid product slot. Please try again.");
                        Console.WriteLine();
                    }                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something has gone wrong. Purchase could not be completed.");
                    successfulPurchase = false;
                }                
            }
            return successfulPurchase;
        }
        /// <summary>
        /// Constructor for Vending Machine object. Sets initial balance to zero and creates a dictionary from the inventory list
        /// </summary>
        public VendingMachine()
        {
            Balance = 0;
            PopulatedDictionary = InstantiateProductDictionary();
        }
        /// <summary>
        /// Current Balance of the vending machine
        /// </summary>
        public decimal Balance { get; private set; }
        /// <summary>
        /// Amount deposited by the customer into the machine.
        /// </summary>
        public decimal DepositedAmount { get; private set; }
        /// <summary>
        /// Allows the customer to feed money into the vending machine
        /// </summary>
        /// <returns>True if money deposited successfully</returns>
        public bool FeedMoney()
        {
            bool isValid = true;
            //while loop set to true initially, we set to false if they make a valid deposit, bring them back to the menu
            while (isValid)
            {
                Console.WriteLine("Please enter your money in whole dollars.");
                decimal depositAmount = decimal.Parse(Console.ReadLine());
                //If statement with calculation to make sure deposit is in whole dollars
                if (depositAmount > 0 && ((depositAmount * 100) % 100 == 0))
                {
                    DepositedAmount = depositAmount;
                    Balance += depositAmount;
                    WriteFeedMoneyToLog();
                    Console.WriteLine($"Current money provided is {Balance:C2}");
                    isValid = false;
                } 
                //Else statement prompts customer if they try to deposit without using whole dollars
                else
                {
                    Console.WriteLine("Whole dollars only please");
                }
            }
                return !isValid;
        }
        /// <summary>
        /// Product Inventory as a list of string arrays.  Used to generate product dictionary.
        /// </summary>
        public List<string[]> ProductList { get
        {
           return ConvertToListOfArrays();
        }
        }
/// <summary>
/// Dictionary with product slot as Key and product classes using the IProduct interface as the values
/// </summary>
public Dictionary<string, IProduct> PopulatedDictionary { get; private set; }
        /// <summary>
        /// Displays the product list in the console
        /// </summary>
        /// <returns>True if product list displays</returns>
        public bool DisplayProductList()
        {
            // writes product list header to console
            Console.WriteLine("Slot".PadRight(10) + "Name".PadRight(20) + "Price".PadRight(10) + "Amount".PadRight(10));
            //foreach loop grabs the info from the dictionary so it can be displayed in proper format on the console
            foreach (IProduct product in PopulatedDictionary.Values)
            {
                Console.Write($"{product.Slot}".PadRight(10));
                Console.Write($"{product.Name}".PadRight(20));
                Console.Write($"{product.Price}".PadRight(10));
                if (product.InventoryCount > 0)
                {
                    Console.Write($"{product.InventoryCount}".PadRight(10));
                } else if (product.InventoryCount == 0)
                {
                    Console.WriteLine("SOLD OUT".PadRight(10));
                }
                    Console.WriteLine();
            }
            return true;
        }

        /// <summary>
        /// Reads the product list from the inventory CSV file and saves it as a list of string arrays.
        /// </summary>
        /// <returns>List of String Arrays</returns>
        public List<string[]> ConvertToListOfArrays()
        {
            List<string[]> listOfArrays = new List<string[]>();
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Student\workspace\Pairs\csharp-capstone-module-1-team-5\vendingmachine.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] productInfo = line.Split('|');
                        listOfArrays.Add(productInfo);
                    }
                }
            }
            catch (Exception e)
            {               
                Console.WriteLine("File Name Is Incorrect");
            }
            return listOfArrays;
        }
        /// <summary>
        /// Returns a dictionary with the slot as the Key Value, this dictionary will allow us to display the items for purchase
        /// </summary>
        /// <returns>Dictionary with full product info, using slot of each product as the key</returns>
        public Dictionary<string, IProduct> InstantiateProductDictionary()
        {
            Dictionary<string,IProduct> populatedDictionary = new Dictionary<string,IProduct>();
            int inventoryCount = 5;            
            //foreach loop to populate the dictionary
            foreach (string[] array in ProductList)
            {
                if (array[3] == "Chip")
                {
                    populatedDictionary.Add(array[0], new Chips(array[1], decimal.Parse(array[2]), array[0], inventoryCount));
                }
                else if (array[3] == "Candy")
                {
                    populatedDictionary.Add(array[0], new Candy(array[1], decimal.Parse(array[2]), array[0], inventoryCount));
                }
                else if (array[3] == "Drink")
                {
                    populatedDictionary.Add(array[0], new Drink(array[1], decimal.Parse(array[2]), array[0], inventoryCount));
                }
                else if (array[3] == "Gum")
                {
                    populatedDictionary.Add(array[0], new Gum(array[1], decimal.Parse(array[2]), array[0], inventoryCount));
                }
            }
            return populatedDictionary;
        }        
    } 
}
