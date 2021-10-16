using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_JWT_Auth.DAL.Services
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
    }
}
