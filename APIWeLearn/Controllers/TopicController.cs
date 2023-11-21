using APIWeLearn.Controllers;
using APIWeLearn.Models;
using APIWeLearn.Resquest;
using APIWeLearn.Resquest.Topic;
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
        [Route("buscar/{categoryName}")]
        public ActionResult GetSelectedCategory(string categoryName)
        {
            List<Topic> topics = new List<Topic>();
            topics = Topic.getSelectedTopics(categoryName);
            if (topics == null)
            {
                return NotFound();
            }

            return Ok(topics);
        }

        [HttpPost("topicInVideo")]
        public ActionResult PostTopicVideo([FromBody] TopicVideoPostRequest topic)
        {
            
            if (Topic.postTopicVideo(topic))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("topicInForum")]
        public ActionResult PostTopicForum([FromBody] TopicForumPostRequest topic)
        {
            
            if (Topic.postTopicForum(topic))
            {
                return Ok();
            }

            return BadRequest();
        }




        [HttpPut]
        [Route("putTopicDes/{topicID}")]
        public ActionResult putTopicDes(int topicID)
        {

            if (Topic.putTopicDes(topicID))
            {
                return Ok();
            }

            return BadRequest();
        }
        [HttpPut]
        [Route("delTopic/{topicID}")]
        public ActionResult delTopicDes(int topicID)
        {

            if (Topic.delTopic(topicID))
            {
                return Ok();
            }

            return BadRequest();
        }


    }
}
