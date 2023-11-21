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
        [Route("listar/{topicID}")]
        public IActionResult GetAnswers(int topicID)
        {
            List<Answers> answers = new List<Answers>();
            answers = Answers.getAnswers(topicID);
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
