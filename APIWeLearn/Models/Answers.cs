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
        DateTime? data_resposta;
        string? pier_sit_reg;

        public Answers(int? id, DateTime? data_resposta, string? pier_sit_reg, string? nome_usuario, string? conteudo_resposta)
        {
            this.id = id;
            this.nome_usuario = nome_usuario;
            this.conteudo_resposta = conteudo_resposta;
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
        public DateTime? Data_resposta { get => data_resposta; set => data_resposta = value; }
        public string? Pier_sit_Reg { get => pier_sit_reg; set => pier_sit_reg = value; }
        public string? Nome_usuario { get => nome_usuario; set => nome_usuario = value; }
        public string? Conteudo_resposta { get => conteudo_resposta; set => conteudo_resposta = value; }
    }
}
