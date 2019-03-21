using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SP19.P05.Web.Data;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace SP19.P05.Web.Features.UserFolder
{
    public class Auth : IAuth
    {
        private readonly DataContext _context;
        

        public Auth(DataContext context)
        {
            _context = context;
        }

        public string passwordHashing(string password)
        {

            byte[] salt = System.Text.Encoding.Unicode.GetBytes("prashant");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public async Task<bool> checkIfUsernameExists(string username)
        {
            if (await _context.UserTables.AnyAsync(x => x.Username == username))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> checkIfEmailExists(string email)
        {
            if (await _context.UserTables.AnyAsync(x => x.Email == email))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> login(string usernameOrEmail, string password)
        {

            var user =  _context.UserTables.FirstOrDefault(x => (x.Username == usernameOrEmail || x.Email == usernameOrEmail) && x.Password == password);
            if (user == null)
            {
                return false;
            }

            return true;
        }




    }
}
