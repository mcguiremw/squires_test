using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCode.Services
{
    public interface ITokenService
    {
        string CreateToken(string userName);
    }
}
