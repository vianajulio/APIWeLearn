namespace APIWeLearn.Resquest
{
    public class TopicVideoPostRequest
    {
        public string TopicTitle { get; set; }
        public string TopicDescription { get; set; }
        public DateTime TopicDate { get; set; }
        public int TopicCategoryID { get; set; }
        public int TopicUserID { get; set; }
        public int? TopicVideoID { get; set; }
        public string TopicStatus { get; set; }
    }
}
