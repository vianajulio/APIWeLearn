using APIWeLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIWeLearn.Controllers 
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : Controller 
    {
        [HttpPost]
        public ActionResult PostClass(string value) {
            Class? aula = JsonConvert.DeserializeObject<Class>(value);
            return Content(aula!.InsertClass());
        }
        [HttpGet]
        public ActionResult GetClass(int idValue) {
            return new JsonResult(JsonConvert.SerializeObject(Models.Class.SearchClasses(idValue)));
        }

        [HttpPut]
        public ActionResult PutClass(int idValue) {
            return new JsonResult(JsonConvert.SerializeObject(Models.Class.DesableClass(idValue)));
        }
    }

}
