using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        public int GetCustomerId();
        public ShoppingCartItem AddProduct(Product product, int quant);
        public ShoppingCartItem RemoveProduct(int id, int quant);
        public decimal GetTotal();
        public ShoppingCartItem GetProductById(int id);
        public List<ShoppingCartItem> GetProducts();
    }
}
