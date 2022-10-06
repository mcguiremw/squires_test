using AppCode.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCode.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRepository(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }
        public async Task<User> GetUser(string name, string password)
        {
            return await _unitOfWork.context.Users.FirstOrDefaultAsync(x => x.Name.Equals(name) && x.Password.Equals(password));
        }
    }
    
}
