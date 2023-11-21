namespace APIWeLearn.Resquest.Topic
{
    public class TopicForumPostRequest
    {
        public string TopicTitle { get; set; }
        public string TopicDescription { get; set; }
        public DateTime TopicDate { get; set; }
        public int TopicCategoryID { get; set; }
        public int TopicUserID { get; set; }
        public string TopicStatus { get; set; }
    }
}
