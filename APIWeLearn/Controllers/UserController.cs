using APIWeLearn.Controllers;
using APIWeLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIWeLearn.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller 
    {
        [HttpPost]
        public IActionResult PostUser(string value) {
            User? user = JsonConvert.DeserializeObject<User>(value);
            return Content(user!.InsertUser());
        }

        [HttpGet]
        public IActionResult GetUser(string json) {
            User? user = JsonConvert.DeserializeObject<User>(json);
            user.SearchUser();
            return new JsonResult(
                JsonConvert.SerializeObject(user));
        }

        [HttpPut]
        public IActionResult PutUser(string value) {
            User? user = JsonConvert.DeserializeObject<User>(value);
            return Content(user!.EditUser());
        }
    }
}
