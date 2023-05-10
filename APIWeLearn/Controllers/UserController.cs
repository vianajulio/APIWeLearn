using APIWeLearn.Controllers;
using APIWeLearn.Models;
using APIWeLearn.Resquest;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIWeLearn.Controllers 
{
    [ApiController]
    [Route("api/usuario")]
    public class UserController : Controller 
    {
        [HttpPost("cadastrar")]
        public IActionResult PostUser([FromBody] RegisterRequest register)
        {
            User user = new User(name: register.Name, email: register.Email, senha: register.Password, pierSitReg: "ATV", dateTime: DateTime.Now);
            if (user.InsertUser())
            {
                return Ok();
            }
            return BadRequest();
        }
       
        [HttpGet("buscar")]
        public IActionResult GetUser(string email) {
            User user = new User(email: email, dateTime: DateTime.Now);
            user.SearchUser();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] LoginResquest login) {
            User user = new User(email: login.Email, senha: login.Password, dateTime: DateTime.Now);
            user.LoginUser();
            if (user == null || user.Id == 0)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("editar")]
        public IActionResult PutUser([FromBody] EditResquest edit) {
            
            User user = new User(id: edit.Id, name: edit.Name, email: edit.Email, senha: edit.Password, pierSitReg: edit.PierSitReg, dateTime: DateTime.Now);
            if (user.EditUser())
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
