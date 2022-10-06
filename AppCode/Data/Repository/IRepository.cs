using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCode.Data.Repository
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Save(T entity);
        bool Remove(T entity);
    }
}
