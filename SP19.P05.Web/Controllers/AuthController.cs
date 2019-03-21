using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.UserFolder;

namespace SP19.P05.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAuth _auth;
        public AuthController(DataContext context, IAuth auth)
        {
            _context = context;
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignupDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _auth.checkIfEmailExists(user.Email) && await _auth.checkIfUsernameExists(user.Username))
            {
                return BadRequest("Username and Email is alreay taken");
            }else if (await _auth.checkIfEmailExists(user.Email))
            {
                return BadRequest("Email is alreay taken");
            }
            else if (await _auth.checkIfUsernameExists(user.Username))
            {
                return BadRequest("Username is alreay taken");
            }

            var newHashedPasswordWithUserObject = new UserTable()
            {
                Username = user.Username,
                Email = user.Email,
                Password = _auth.passwordHashing(user.Password),
                UserRoles = user.UserRoles
            };
            _context.UserTables.Add(newHashedPasswordWithUserObject);
            await _context.SaveChangesAsync();
            /*not returning the hashed password */
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hashPassword = _auth.passwordHashing(user.Password);
            if (!await _auth.login(user.UsernameOrEmail, hashPassword))
            {
                return Unauthorized("Login credentials do not match. Try again!");
            }

            return Ok(user);
        }
    }
}