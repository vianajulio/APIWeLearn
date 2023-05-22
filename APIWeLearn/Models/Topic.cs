using APIWeLearn.Controllers;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace APIWeLearn.Models
{
    public class Topic
    {
        static MySqlConnection fConection = new MySqlConnection(UserSQL.connectiondb);

        int? id_topico;
        string? titulo_topico;
        string? assunto_topico;
        string? nome_usuario;
        string? nome_categoria;
        DateTime? data_topico;
        int? id_aula_topico;
        string? pier_sit_reg;

        //Construtor para realizar post, put e remove
        public Topic(int? id, string? titulo_topico, string? assunto, DateTime? data, string? id_categoria, string? nome_usuario, int? id_aula_topico, string? pier_sit_reg) {
            this.id_topico = id;
            this.titulo_topico = titulo_topico;
            this.assunto_topico = assunto;
            this.nome_usuario = nome_usuario;
            this.nome_categoria = id_categoria;
            this.data_topico = data;
            this.id_aula_topico = id_aula_topico;
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
                    topic.titulo_topico = reader.GetString("titulo_topico");
                    topic.assunto_topico = reader.GetString("assunto_topico");
                    topic.nome_usuario = reader.GetString("nome_usuario");
                    topic.nome_categoria = reader.GetString("nome_categoria");
                    topic.data_topico = reader.GetDateTime("data_topico");
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
            finally
            {
                fConection.Close();
            }
        }
        internal static List<Topic> getSelectedTopics(string nome_categoria)
        {
            try
            {
                List<Topic> topics = new List<Topic>();
                fConection.Open();

                MySqlCommand lQry = new MySqlCommand(TopicSQL.getSelectedTopics, fConection);
                lQry.Parameters.AddWithValue("@nomeCategoria", nome_categoria);
                MySqlDataReader reader = lQry.ExecuteReader();

                while (reader.Read())
                {
                    Topic topic = new Topic();

                    topic.id_topico = reader.GetInt32("id_topico");
                    topic.titulo_topico = reader.GetString("titulo_topico");
                    topic.assunto_topico = reader.GetString("assunto_topico");
                    topic.nome_usuario = reader.GetString("nome_usuario");
                    topic.nome_categoria = reader.GetString("nome_categoria");
                    topic.data_topico = reader.GetDateTime("data_topico");
                    topic.pier_sit_reg = reader.GetString("pier_sit_reg");


                    topics.Add(topic);
                }

                return topics;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fConection.Close();
            }
        }

        public int? Id { get => id_topico; set => id_topico = value; }
        public string? Titulo_Topico { get => titulo_topico; set => titulo_topico = value; }
        public string? Assunto { get => assunto_topico; set => assunto_topico = value; }
        public string? Categoria { get => nome_categoria; set => nome_categoria = value; }
        public string? Nome_Usuario { get => nome_usuario; set => nome_usuario = value; }
        public DateTime? Data { get => data_topico; set => data_topico = value; }
        public int? Id_Aula { get => id_aula_topico; set => id_aula_topico = value; }
        public string? PierSitReg { get => pier_sit_reg; set => pier_sit_reg = value; }

    }
}
