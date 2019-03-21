using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P05.Web.Features.UserFolder
{
    public class UserTable
    {
        
        public int UserTableId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserRoles { get; set; }
    }
}
