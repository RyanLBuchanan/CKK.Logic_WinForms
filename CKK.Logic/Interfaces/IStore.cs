using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public interface IStore
    {
        public StoreItem AddStoreItem(Product prod, int quant);
        public StoreItem RemoveStoreItem(int id, int quant);
        public StoreItem DeleteStoreItem(int id);
        public StoreItem FindStoreItemById(int id);
        public List<StoreItem> GetStoreItems();
    }
}
