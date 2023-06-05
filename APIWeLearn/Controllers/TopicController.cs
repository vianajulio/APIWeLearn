using APIWeLearn.Controllers;
using APIWeLearn.Models;
using Microsoft.AspNetCore.Mvc;

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
        
        [HttpGet]
        [Route("buscar/{nome_categoria}")]
        public ActionResult GetSelectedCategory(string nome_categoria)
        {
            List<Topic> topics = new List<Topic>();
            topics = Topic.getSelectedTopics(nome_categoria);
            if (topics == null)
            {
                return NotFound();
            }

            return Ok(topics);
        }

        [HttpPost("cadastrar")]
        public ActionResult PostTopic([FromBody] Topic topic)
        {
            
            if (Topic.postTopic(topic))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("putTopicDes/{id_topico}")]
        public ActionResult putTopicDes(int id_topico)
        {

            if (Topic.putTopicDes(id_topico))
            {
                return Ok();
            }

            return BadRequest();
        }


    }
}
