using APIWeLearn.Models;
using APIWeLearn.Resquest;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIWeLearn.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoryController : Controller
    {
        [HttpPost("criar")]
        public ActionResult PostCategory([FromBody] CategoryRequest newCategory)
        {
            Category category = new Category(name: newCategory.Name, description: newCategory.Description);
            if (category.InsertCategory())
            {
                return Ok();
            }
            return BadRequest();

        }
        
        [HttpGet("listar")]
        public ActionResult GetAllCategory()
        {
            List<Category> categories = new List<Category>();
            categories = Category.getAllCategory();
            if (categories.Count == 0)
            {
                return NotFound();
            }

            return Ok(categories);
        }



    }
}
