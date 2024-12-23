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
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(StoreProjectDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
