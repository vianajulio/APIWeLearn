using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;

namespace APIWeLearn.Models
{
    public class Topic
    {
        static MySqlConnection fConection = new MySqlConnection(UserSQL.connectiondb);

        int? id_topico;
        string? assunto_topico;
        DateTime? data_topico;
        int? id_categoria_topico;
        int? aulas_id_aula;
        int? aulas_id_usuario_aula;
        string? nome_usuario;
        string? pier_sit_reg;

        public Topic(int? id, string? assunto, DateTime? data, int? id_categoria, string? nome_usuario, string ?pier_sit_reg) { 
            this.id_topico = id;
            this.assunto_topico = assunto;
            this.data_topico = data;
            this.id_categoria_topico = id_categoria;
            this.nome_usuario = nome_usuario;
            this.pier_sit_reg = pier_sit_reg;
        }

        public Topic() { }

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

                    topic.id_topico = reader.GetInt32("id_topico");
                    topic.assunto_topico = reader.GetString("assunto_topico");
                    topic.data_topico = reader.GetDateTime("data_topico");
                    topic.id_categoria_topico = reader.GetInt32("id_categoria_topico");
                    topic.nome_usuario = reader.GetString("nome_usuario");
                    topic.pier_sit_reg = reader.GetString("pier_sit_reg");


                    topics.Add(topic);
                }

                return topics;
            }
            catch (Exception e)
            {

                throw;
                return null;
            }
        }




    }
}
