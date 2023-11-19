using APIWeLearn.Models;
using APIWeLearn.Resquest;
using Microsoft.AspNetCore.Mvc;

namespace APIWeLearn.Controllers 
{
    [ApiController]
    [Route("api/usuario")]
    public class UserController : Controller 
    {
        [HttpPost("register")]
        public IActionResult PostUser([FromBody] RegisterRequest register)
        {
            User user = new User(name: register.Name, email: register.Email, senha: register.Password, userType: register.UserType);
            if (user.InsertUser())
            {
                return Ok();
            }
            return BadRequest();
        }
       
        [HttpGet("search")]
        public IActionResult GetUser(string email) {
            User user = new User(email: email).SearchUser();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] LoginResquest login) {
            User user = new User(email: login.Email, senha: login.Password, userType: login.UserType);
            user.LoginUser();
            if (user == null || user.Id == 0)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("editar")]
        public IActionResult PutUser([FromBody] EditResquest edit) {
            
            User user = new User(name: edit.Name, email: edit.Email, senha: edit.Password, userType: edit.UserType);
            if (user.EditUser())
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
