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
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        

        public StoreRepository(StoreProjectDbContext dbContext):base(dbContext)
        {
          
        }
     
     
    }
}
