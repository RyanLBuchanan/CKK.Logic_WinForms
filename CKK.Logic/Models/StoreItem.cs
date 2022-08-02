using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class StoreItem : InventoryItem
    {
        // NO VARIABLES PER UML???
        //private Product Product;
        //private int Quantity;

        // StoreItem constructor that receives two parameters
        public StoreItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
