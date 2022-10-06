using AppCode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCode.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUser(string name, string password);
    }    
}
