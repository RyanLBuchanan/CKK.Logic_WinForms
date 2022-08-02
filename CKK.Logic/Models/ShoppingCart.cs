using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private Customer Customer;
        public List<ShoppingCartItem> Products { get; set; }

        // ShoppingCart constructor that receives one parameters
        public ShoppingCart(Customer cust)
        {
            // Make sure that the GetCustomerId() returns
            // the same Id as the customer that was put in the argument in the constructor
            Customer = cust;
            Products = new();
        }

        public int GetCustomerId()
        {
            // Returns the customer's id 
            return Customer.Id;
        }

        public ShoppingCartItem AddProduct(Product prod, int quant)
        {
            ShoppingCartItem myItem = new(prod, quant);

            if (quant > 0)
            {
                foreach (ShoppingCartItem item in Products)
                {
                    if (item.Product == prod)
                    {
                        item.Quantity += quant;
                        return item;
                    }
                }

                Products.Add(myItem);
                return myItem;
            }
            else
            {
                if (quant <= 0) // Validate
                {
                    throw new InventoryItemStockTooLowException();
                }

                return null;
            }
        }

        public ShoppingCartItem RemoveProduct(int id, int quant)
        {
            // If the product does not exist, throw ProductDoesNotExistException
            if (GetProductById(id) == null)
            {
                throw new ProductDoesNotExistException();
            }

            if (quant > 0)
            {
                var item = GetProductById(id);

                if (item.Quantity - quant > 0)
                {
                    item.Quantity -= quant;
                    return item;
                }
                else
                {
                    Products.Remove(item);
                    item.Quantity = 0;
                    return item;
                }
            }
            else  
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        public decimal GetTotal()
        {
            var getTotal =
                from item in Products
                where item.Quantity != 0
                select item;

            decimal Total = 0;

            foreach (ShoppingCartItem s in getTotal)
            {
                Total += s.GetTotal();
            }

            return Total;
        }

        public ShoppingCartItem GetProductById(int id)
        {

            if (id < 0) // Validate
            {
                throw new InvalidIdException();
            }


            var getProductsById =
                from item in Products
                where item.Product.Id == id && item.Quantity != 0
                select item;

            return getProductsById.FirstOrDefault();
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}