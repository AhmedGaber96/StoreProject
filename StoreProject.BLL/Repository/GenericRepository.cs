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
//hello form the other side form github
//hello 
//hello
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StoreProjectDbContext _dbContext;

        public GenericRepository(StoreProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(T entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
          
        }

        public int Delete(int id)
        {
            var entity = GetById(id);
            if (entity is null)
            {
                return 0;
            }
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
            
        }

        public T GetById(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
                  if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
