using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.BLL.Interface
{
    public interface IAddQuantity
    {
        public int GetQuantity(int storeId, int itemId);
        public int AddStoreItem(int storeId, int itemId, int quantity);
    }
}
