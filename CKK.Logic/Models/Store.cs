using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        public List<StoreItem> Products { get; set; }

        public Store()
        {
            Products = new List<StoreItem>();
        }

        public StoreItem AddStoreItem(Product prod, int quant)
        {
            // Initialize new ID numbers
            int newId = 101;

            // If the item already exists in the List,
            // then you should add the quantity variable of that item and not add new StoreItem.
            if (quant > 0)
            {
                StoreItem myItem = FindStoreItemById(prod.Id);

                if (myItem != null && prod.Id != 0)  // If product's current ID is 0, give product new ID
                {
                    myItem.Quantity += quant;
                }
                else
                {
                    myItem = new StoreItem(prod, quant);
                    myItem.Product.Id = newId;  // Give store item with 0 as current ID new id, beginning with 101
                    newId++; // Increment newId
                    Products.Add(myItem);
                }
                return myItem;
            }
            else
            {
                throw new InventoryItemStockTooLowException("The value entered must be a postive number");
            }
        }

        public StoreItem RemoveStoreItem(int id, int quant)
        {
            // If the product does not exist, throw ProductDoesNotExistException
            if (FindStoreItemById(id) == null)
            {
                throw new ProductDoesNotExistException();
            }
            
            //If the value is going to be less than zero,
            //then it should stay at 0,
            // and NOT remove the item from the store
            if (quant > 0)
            {

                foreach (StoreItem item in Products)
                {
                    if (id == item.Product.Id)
                    {
                        if (item.Quantity - quant > 0)
                        {
                            item.Quantity -= quant;
                            return item;
                        }
                        else
                        {
                            item.Quantity = 0;
                            return item;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The value entered must be a postive number");
            }
            
            return null;
        }

        public StoreItem DeleteStoreItem(int id)
        {
            // If the product does not exist, throw ProductDoesNotExistException
            if (FindStoreItemById(id) == null)
            {
                throw new ProductDoesNotExistException();
            }
            else
            {
                Products.RemoveAt(id);
            }

            return null;
        }

        public StoreItem FindStoreItemById(int id)
        {

            if (id < 0) // Validate
            {
                throw new InvalidIdException("The value entered must be a postive number");
            }


            //This will return the product that has the same Id(if there is one)
            var findStoreItemId =
                from item in Products
                where item.Product.Id == id
                select item;

            return findStoreItemId.FirstOrDefault();
        }

        public List<StoreItem> GetStoreItems()
        {
            //Should return correct product
            //If it is an invalid productNumber, then it will return null
            //If there is not an item in the desired spot, it will return null
            return Products;
        }
    }
}
