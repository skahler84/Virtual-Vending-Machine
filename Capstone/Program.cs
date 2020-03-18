using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate vendingMachine
            VendingMachine vendingMachine = new VendingMachine();
            Console.WriteLine("Welcome To the Vending Machine.");            
            
            int userInput;
            bool keepRunning = true;
            //while loop initially set to true so that customer can make selections from menus until they exit the vending machine
            while (keepRunning)
            {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
                try
                {   //parse the customer input to an int and use if/else if statements to navigate options based on their selection
                    userInput = int.Parse(Console.ReadLine());
                    if (userInput == 1)
                    {
                        Console.Clear();
                        vendingMachine.DisplayProductList();
                        Console.WriteLine();
                    }
                    else if (userInput == 2)
                    {
                        Console.Clear();
                        bool keepPurchasing = true;
                        while (keepPurchasing)
                        {
                            Console.WriteLine("(1) Feed Money");
                            Console.WriteLine("(2) Select Product");
                            Console.WriteLine("(3) Finish Transaction");
                            Console.WriteLine($"Your current balance is {vendingMachine.Balance:C2}");
                            try
                            {
                                userInput = int.Parse(Console.ReadLine());
                                if (userInput == 1)
                                {
                                    Console.Clear();
                                    vendingMachine.FeedMoney();
                                    Console.Clear();
                                }
                                else if (userInput == 2 && vendingMachine.Balance > 0)
                                {
                                    Console.Clear();
                                    vendingMachine.DisplayProductList();
                                    vendingMachine.MakePurchase();                                    
                                } else if (userInput == 2 && vendingMachine.Balance == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please deposit money first.");
                                }
                                else if (userInput == 3)
                                {
                                    Console.Clear();                                    
                                    keepPurchasing = !vendingMachine.FinishPurchase(); 
                                } else
                                {
                                    Console.WriteLine("Please enter a valid selection number.");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid selection choice, please try again.");
                            }
                        }
                    } else if (userInput == 3)
                    {
                        keepRunning = false;
                        Console.Clear();
                        Console.WriteLine("Thank you for using the vending machine!");
                        vendingMachine.WriteBlankLineOnExitToLog();                            
                    } else
                    {
                        Console.WriteLine("Please enter a valid selection number.");
                    }                        
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter the number of the menu item");
                }
            }   
        }
    }
}
