using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace APIWeLearn.Models
{
    public class Answers
    {
        static MySqlConnection fConection = new MySqlConnection(UserSQL.connectiondb);

        int? id;
        string? nome_usuario;
        string? conteudo_resposta;
        string? assunto_topico;
        DateTime? data_resposta;
        string? pier_sit_reg;

        public Answers(int? id, string? conteudo_respostas, DateTime? data_resposta, string? pier_sit_reg, string? nome_usuario, string? assunto_topico)
        {
            this.id = id;
            this.nome_usuario = nome_usuario;
            this.assunto_topico = assunto_topico;
            this.conteudo_resposta = conteudo_respostas;
            this.data_resposta = data_resposta;
            this.pier_sit_reg = pier_sit_reg;
        }

        public Answers() { }

        internal static List<Answers> getAnswers(int? id_topico)
        {
            try
            {
                List<Answers> ans = new List<Answers>();
                fConection.Open();

                MySqlCommand lQuery = new MySqlCommand(AnswersSQL.getAllAnswers, fConection);
                lQuery.Parameters.AddWithValue("@id_topico", id_topico);
                MySqlDataReader reader = lQuery.ExecuteReader();

                while (reader.Read())
                {
                    Answers answers = new Answers();

                    answers.id = reader.GetInt32("id_resposta");
                    answers.nome_usuario = reader.GetString("nome_usuario");
                    answers.assunto_topico = reader.GetString("assunto_topico");
                    answers.conteudo_resposta = reader.GetString("conteudo_resposta");
                    answers.data_resposta = reader.GetDateTime("data_resposta");
                    answers.pier_sit_reg = reader.GetString("pier_sit_reg");

                    ans.Add(answers);
                }

                return ans;
            }
            catch (Exception e) { throw; }
            finally { fConection.Close(); }
        }

        public int? Id { get => id; set => id = value; }
        public string? Conteudo_Respostas { get => conteudo_resposta; set => conteudo_resposta = value; }
        public DateTime? Data_Resposta { get => data_resposta; set => data_resposta = value; }
        public string? Pier_Sit_Reg { get => pier_sit_reg; set => pier_sit_reg = value; }
        public string? Nome_Usuario { get => nome_usuario; set => nome_usuario = value; }
        public string? Assunto_Topico { get => assunto_topico; set => assunto_topico = value; }
    }
}
