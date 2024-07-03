using LoginRegisterAPI.Context;
using LoginRegisterAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginRegisterAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] User userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }
            var user = _context.Users.FirstOrDefault(u => u.Email == userObj.Email && u.Password == userObj.Password);
            if(user == null)
            {
                return NotFound(new {Message = "User Not Found"});
            }

            return Ok(new {Message = "Login Success!"});
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            _context.Users.Add(userObj);
            _context.SaveChanges();
            return Ok(new {Message = "User Registered!"});
        }
    }
}
