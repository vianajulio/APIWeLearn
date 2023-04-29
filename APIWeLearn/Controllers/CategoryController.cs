using APIWeLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIWeLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        [HttpPost]
        public ActionResult PostCategory(string value)
        {
            Category? category = JsonConvert.DeserializeObject<Category>(value);
            return Content(category!.InsertCategory());
        }
        
        [HttpGet]
        public ActionResult GetCategory(int pIdCategory)
        {
            return new JsonResult(
                JsonConvert.SerializeObject(Category.SearchCategory(pIdCategory)));
        }
     

    }
}
