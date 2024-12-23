using StoreProject.BLL.Interface;
using StoreProject.DAL.Context;
using StoreProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.BLL.Repository
{
    public class AddQuantity : IAddQuantity
    {
        private readonly StoreProjectDbContext _dbContext;

        public AddQuantity(StoreProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public StoreItem GetStoreItem(int storeId, int itemId)
        {
            var storeItem = _dbContext.storeItem
           .FirstOrDefault(si => si.StoreId == storeId && si.ItemId == itemId);
          if(storeItem is null)
            {
                return null;

            }
            else
            {
                return storeItem;
            }
        }
        public int GetQuantity(int storeId, int itemId)
        {

            var storeItem = GetStoreItem(storeId, itemId);
           
            return storeItem?.Quantity ?? 0;
        }


        public int AddStoreItem(int storeId, int itemId,int quantity)
        {
            var storeIte = GetStoreItem(storeId, itemId);

            if(storeIte == null)
            {
                var storeItem = new StoreItem
                {
                    StoreId = storeId,
                    ItemId = itemId,
                    Quantity = quantity
                };
                _dbContext.storeItem.Add(storeItem);


                return _dbContext.SaveChanges();
            }
            else
            {
                storeIte.Quantity+=quantity;
                _dbContext.Update(storeIte);
                return _dbContext.SaveChanges();


            }

          
        }
    }
}
