using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// An interface with common aspects of the items for purchase (name, price, slot and inventory count)
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The price of the product
        /// </summary>
        decimal Price { get; }
        /// <summary>
        /// The slot in the machine at which the product is stored
        /// </summary>
        string Slot { get; }
        /// <summary>
        /// The amount of the product in the machine
        /// </summary>
        int InventoryCount { get; set; }
        /// <summary>
        /// Method that creates specific return message for Chips
        /// </summary>
        /// <returns>Product's output message</returns>
        string ProductOutputMessage();
    }
}
