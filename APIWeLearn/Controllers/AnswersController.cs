using APIWeLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;

namespace APIWeLearn.Controllers
{
    [ApiController]
    [Route("api/respostas")]
    public class AnswersController : Controller
    {
        [HttpGet]
        [Route("listar/{id_topico}")]
        public IActionResult GetAnswers(int id_topico)
        {
            List<Answers> answers = new List<Answers>();
            answers = Answers.getAnswers(id_topico);
            if (answers == null)
            {
                return NotFound();
            }
            return Ok(answers);
        }

        [HttpPost("cadastrar")]
        public IActionResult postAnswer(Answers answer)
        {
            if (Answers.postAnswer(answer))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
