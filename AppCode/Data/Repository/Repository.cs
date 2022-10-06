using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCode.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }
        public async  Task<T> Get(int id)
        {
            return await _unitOfWork.context.Set<T>().FindAsync(id);
        }

        public async  Task<IEnumerable<T>> GetAll()
        {
            return await _unitOfWork.context.Set<T>().ToListAsync();
        }

        public  bool Remove(T entity)
        {            
           _unitOfWork.context.Set<T>().Remove(entity);
           return _unitOfWork.Complete().Result;
        }

        public async  Task<bool> Save(T entity)
        {
            await _unitOfWork.context.Set<T>().AddAsync(entity);
           return _unitOfWork.Complete().Result;
        }
    }
}
