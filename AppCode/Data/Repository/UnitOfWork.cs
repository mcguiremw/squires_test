using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCode.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public  DataContext context { get; }

        public UnitOfWork(DataContext dataContext)
        {
            context = dataContext;
        }
       
        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
