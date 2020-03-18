using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    //Gum inherits from IProduct
    public class Gum : IProduct
    {
        /// <summary>
        /// Constructor for product with shared characteristics
        /// </summary>
        /// <param name="name">Name of product as a string</param>
        /// <param name="price">Price of product as a decimal</param>
        /// <param name="slot">Slot of product as a string</param>
        /// <param name="inventoryCount">Amount of product as an int</param>
        public Gum(string name, decimal price, string slot, int inventoryCount)
        {
            if (name == null)
            {
                Name = "Invalid Product Name";
            }
            else
            {
                Name = name;
            }
            if (price < 0)
            {
                Price = 0M;
            }
            else
            {
                Price = price;
            }
            if (slot == null)
            {
                Slot = "Invalid Slot";
            }
            else
            {
                Slot = slot;
            }
            if (inventoryCount < 0)
            {
                InventoryCount = 0;
            }
            else
            {
                InventoryCount = inventoryCount;
            }
        }
        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal Price { get; }
        /// <summary>
        /// The slot in the machine at which the product is stored
        /// </summary>
        public string Slot { get; }
        /// <summary>
        /// The amount of the product in the machine
        /// </summary>
        public int InventoryCount { get; set; }
        /// <summary>
        /// Method that creates specific return message for Chips
        /// </summary>
        /// <returns>Product's output message</returns>
        public string ProductOutputMessage()
        {
            return "Chew Chew, Yum!";
        }
    }
}
