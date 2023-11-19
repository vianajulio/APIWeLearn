using APIWeLearn.Controllers;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace APIWeLearn.Models
{
    public class Topic_APP
    {
        static MySqlConnection fConection = new MySqlConnection(UserSQL.connectiondb);

        private int? id;
        private string? assunto_topico;
        private string? pier_sit_reg;
        private DateTime? data_topico;
        private string? nome_categoria;
        private string? nome_usuario;


        public Topic_APP(int? id, string? assunto_topico, string? pier_sit_reg, DateTime? data,string? nome_categoria, string? nome_usuario)
        {
            this.id = id;
            this.assunto_topico = assunto_topico;
            this.pier_sit_reg = pier_sit_reg;
            this.data_topico = data;
            this.nome_categoria = nome_categoria;
            this.nome_usuario = nome_usuario;
        }

        public Topic_APP() { }

        public List<Topic_APP> getTopics()
        {
            try
            {
                List<Topic_APP> topicsList = new List<Topic_APP>();
                fConection.Open();

                MySqlCommand lQuery = new MySqlCommand(TopicSQL.getTopics, fConection);
                MySqlDataReader reader = lQuery.ExecuteReader();

                while (reader.Read())
                {
                    Topic_APP topic = new Topic_APP();

                    topic.id = reader.GetInt32("id_topico");
                    topic.assunto_topico = reader.GetString("assunto_topico");
                    topic.nome_usuario = reader.GetString("nome_usuario");
                    topic.nome_categoria = reader.GetString("nome_categoria");
                    topic.data_topico = reader.GetDateTime("data_topico");
                    topic.pier_sit_reg = reader.GetString("pier_sit_reg");

                    topicsList.Add(topic);
                }
                Console.WriteLine(topicsList);

                return topicsList;

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

        public int? Id { get => id; set => id = value; }
        public string? PierSitReg { get => pier_sit_reg; set => pier_sit_reg = value; }
        public string? Assunto { get => assunto_topico; set => assunto_topico = value; }
        public DateTime? Data { get => data_topico; set => data_topico = value; }
        public string? Categoria { get => nome_categoria; set => nome_categoria = value; }
        public string? Nome_Usuario { get => nome_usuario; set => nome_usuario = value; }

    }
}
