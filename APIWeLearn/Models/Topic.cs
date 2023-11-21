using APIWeLearn.Controllers;
using APIWeLearn.Resquest;
using APIWeLearn.Resquest.Topic;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace APIWeLearn.Models
{
    public class Topic
    {
        static MySqlConnection fConection = new MySqlConnection(UserSQL.connectiondb);

        int? topicID;
        string? topicTitle;
        string? topicDescription;
        string? topicUserName;
        string? topicCategoryID;
        DateTime? topicDate;
        int? topicVideoID;
        string? topicStatus;

        public Topic() {}
    
        public Topic(int? id, string? topicTitle, string? topicDescription, DateTime? date, string? topicCategoryID, string? topicUserName, int? topicVideoID, string? topicStatus)
        {
            this.topicID = id;
            this.topicTitle = topicTitle;
            this.topicDescription = topicDescription;
            this.topicUserName = topicUserName;
            this.topicCategoryID = topicCategoryID;
            this.topicDate = date;
            this.topicVideoID = topicVideoID;
            this.topicStatus = topicStatus;
        }

        internal List<Topic> getTopics()
        {
            try
            {
                List<Topic> topics = new List<Topic>();
                fConection.Open();

                MySqlCommand lQuery = new MySqlCommand(TopicSQL.getTopics, fConection);
                MySqlDataReader reader = lQuery.ExecuteReader();

                while (reader.Read())
                {
                    Topic topic = new Topic();

                    topic.topicID = reader.GetInt32("topicID");
                    topic.topicTitle = reader.GetString("topicTitle");
                    topic.topicDescription = reader.GetString("topicContent");
                    topic.topicUserName = reader.GetString("topicUserName");
                    topic.topicCategoryID = reader.GetString("topicCategoryID");
                    topic.topicDate = reader.GetDateTime("data_topico");
                    topic.topicStatus = reader.GetString("topicStatus");

                    topics.Add(topic);
                }

                return topics;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fConection.Close();
            }
        }
        internal static List<Topic> getSelectedTopics(string topicCategoryID)
        {
            try
            {
                List<Topic> topics = new List<Topic>();
                fConection.Open();

                MySqlCommand lQry = new MySqlCommand(TopicSQL.getSelectedTopics, fConection);
                lQry.Parameters.AddWithValue("@nomeCategoria", topicCategoryID);
                MySqlDataReader reader = lQry.ExecuteReader();

                while (reader.Read())
                {
                    Topic topic = new Topic();

                    topic.topicID = reader.GetInt32("topicID");
                    topic.topicTitle = reader.GetString("topicTitle");
                    topic.topicDescription = reader.GetString("topicContent");
                    topic.topicUserName = reader.GetString("topicUserName");
                    topic.topicCategoryID = reader.GetString("topicCategoryID");
                    topic.topicDate = reader.GetDateTime("data_topico");
                    topic.topicStatus = reader.GetString("topicStatus");


                    topics.Add(topic);
                }

                return topics;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fConection.Close();
            }
        }
        internal static bool postTopicVideo(TopicVideoPostRequest topic)
        {
            try
            {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(TopicSQL.postTopico, fConection);

                lQry.Parameters.AddWithValue("@topicTitle", topic.TopicTitle);
                lQry.Parameters.AddWithValue("@topicDescription", topic.TopicDescription);
                lQry.Parameters.AddWithValue("@topicDate", DateTime.Now);
                lQry.Parameters.AddWithValue("@topicCategoryID", topic.TopicCategoryID);
                lQry.Parameters.AddWithValue("@topicUserID", topic.TopicUserID);
                lQry.Parameters.AddWithValue("@topicVideoID", topic.TopicVideoID);

                lQry.ExecuteReader();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fConection.Close();
            }
        }
        internal static bool postTopicForum(TopicForumPostRequest topic)
        {
            try
            {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(TopicSQL.postTopico, fConection);

                lQry.Parameters.AddWithValue("@topicTitle", topic.TopicTitle);
                lQry.Parameters.AddWithValue("@topicDescription", topic.TopicDescription);
                lQry.Parameters.AddWithValue("@topicDate", DateTime.Now);
                lQry.Parameters.AddWithValue("@topicCategoryID", topic.TopicCategoryID);
                lQry.Parameters.AddWithValue("@topicUserID", topic.TopicUserID);

                lQry.ExecuteReader();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fConection.Close();
            }
        }

        internal static bool putTopicDes(int topicID)
        {
            try
            {
                fConection.Open();

                MySqlCommand lQry = new MySqlCommand(TopicSQL.putTopicsDES, fConection);
                lQry.Parameters.AddWithValue("@topicID", topicID);

                lQry.ExecuteReader();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fConection.Close();
            }
        }    
        internal static bool delTopic(int topicID)
        {
            try
            {
                fConection.Open();

                MySqlCommand lQry = new MySqlCommand(TopicSQL.delTopico, fConection);
                lQry.Parameters.AddWithValue("@topicID", topicID);

                lQry.ExecuteReader();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fConection.Close();
            }
        }

        public int? Id { get => topicID; set => topicID = value; }
        public string? Titulo_topico { get => topicTitle; set => topicTitle = value; }
        public string? Assunto { get => topicDescription; set => topicDescription = value; }
        public string? Categoria { get => topicCategoryID; set => topicCategoryID = value; }
        public string? Nome_usuario { get => topicUserName; set => topicUserName = value; }
        public DateTime? Data { get => topicDate; set => topicDate = value; }
        public int? Id_aula { get => topicVideoID; set => topicVideoID = value; }
        public string? Pier_sit_reg { get => topicStatus; set => topicStatus = value; }

    }
}
