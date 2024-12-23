using StoreProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.BLL.Interface
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
        int Add(T store);
        int Update(T store);
        int Delete(int id);
    }
}
