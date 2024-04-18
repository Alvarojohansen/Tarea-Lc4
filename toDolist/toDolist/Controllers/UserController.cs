using Microsoft.AspNetCore.Mvc;
using toDolist.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace toDolist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll() 
        {
            var allUsers = new List<User>
            {
            new User {
                Id = 1,
                Name = "alvaro",
                Email="johansenalvaro@gmail.com"
            }
            };
            return Ok(allUsers);
        }
    }
}
