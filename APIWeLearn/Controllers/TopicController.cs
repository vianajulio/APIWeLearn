using APIWeLearn.Controllers;
using APIWeLearn.Models;
using APIWeLearn.Resquest;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace APIWeLearn.Controllers
{
        [ApiController]
        [Route("api/topico")]
    public class TopicController : Controller
    {
        [HttpGet("listar")]
        public IActionResult GetTopic()
        {
            Topic topic = new Topic();
            List<Topic> listTopics = topic.getTopics();
            if (listTopics == null || listTopics.Count == 0)
            {
                return NotFound();
            }

            return Ok(listTopics);

        }

    }
}
