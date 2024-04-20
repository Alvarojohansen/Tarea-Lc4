using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using toDolist.data;
using toDolist.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace toDolist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly TodoContext _context;
        public UserController(TodoContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var allUser = await _context.Users.ToListAsync();

            return Ok(allUser);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<User>>> GetUserById(int id)
        {
            var User = await _context.Users.FindAsync(id);

            if (User is null)
                return NotFound("User null");

            return Ok(User);

        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser( User updatedUser)
        {
            var dbUser = await _context.Users.FindAsync(updatedUser.Id);

            if (dbUser is null)
                return NotFound("User not found");

            dbUser.Name = updatedUser.Name;
            dbUser.Email = updatedUser.Email;
            dbUser.Address = updatedUser.Address;
            
            await _context.SaveChangesAsync();
            return Ok(dbUser);

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var User = await _context.Users.FindAsync(id);

            if (User is null)
                return NotFound("User null");

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return Ok(User);

        }

    }
}
