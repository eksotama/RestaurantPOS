using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P05.Web.Features.UserFolder
{
    public interface IAuth
    {
        string passwordHashing(string password);
        Task<bool> checkIfUsernameExists(string username);
        Task<bool> checkIfEmailExists(string email);
        Task<bool> login(string username, string password);
    }
}
