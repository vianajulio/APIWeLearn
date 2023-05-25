using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace APIWeLearn.Models
{
    public class Class
    {
        static MySqlConnection fConnection = new MySqlConnection(ClassSQL.connectiondb);

        private int? id;
        private string? title;
        private string? description;
        private string? thumbnail;
        private string? video;
        private DateTime? date;
        private int? id_user_class;
        private int? id_category_class;
        private string? pierSitReg;

        [JsonConstructor]
        public Class(int? id, string? title, string? description, string? thumbnail,
            string? video, DateTime? date, int? id_user_class, int? id_category_class, string? pierSitReg)
        {
            this.Id = id;
            this.Title = title!;
            this.Description = description!;
            this.Thumbnail = thumbnail!;
            this.Video = video!;
            this.Date = date!;
            this.Id_user_class = id_user_class!;
            this.Id_category_class = id_category_class!;
            this.PierSitReg = pierSitReg!;
        }

        public Class(int? id, string? title, string? description, string? thumbnail,
            string? video, DateTime? date)
        {
            this.Id = id;
            this.Title = title!;
            this.Description = description!;
            this.Thumbnail = thumbnail!;
            this.Video = video!;
            this.Date = date!;
        }

        public Class(string? title, string? description, string? thumbnail, string? video,
            int? id_user_class, int? id_category_class)
        {
            this.Title = title!;
            this.Description = description!;
            this.Thumbnail = thumbnail!;
            this.Video = video!;
            this.Date = DateTime.Now;
            this.Id_user_class = id_user_class!;
            this.Id_category_class = id_category_class!;
            pierSitReg = "ATV";
        }

        internal string InsertClass()
        {
            try
            {
                fConnection.Open();
                MySqlCommand lQry = new MySqlCommand(ClassSQL.insertClass, fConnection);
                lQry.Parameters.AddWithValue("@title", this.title);
                lQry.Parameters.AddWithValue("@description", this.description);
                lQry.Parameters.AddWithValue("@thumbnail_url", this.thumbnail);
                lQry.Parameters.AddWithValue("@video_url", this.video);
                lQry.Parameters.AddWithValue("@data", this.date);
                lQry.Parameters.AddWithValue("@id_user_class", this.id_user_class);
                lQry.Parameters.AddWithValue("@id_category_class", this.id_category_class);

                lQry.ExecuteNonQuery();
                fConnection.Close();
                return $"Class {this.title} cadastrada com sucesso!";

            }
            catch (Exception e)
            {

                if (fConnection.State == System.Data.ConnectionState.Open)
                    fConnection.Close();
                return e.Message;
            }
        }

        internal static List<Class> SearchClasses(int pIdCLass)
        {
            try
            {
                fConnection.Open();
                MySqlCommand lQry = new MySqlCommand(ClassSQL.selectClasses, fConnection);
                List<Class> lista = new List<Class>();

                lQry.Parameters.AddWithValue("@id_categoria_aula", pIdCLass);

                MySqlDataReader reader = lQry.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(
                        new Class(
                            int.Parse(reader["cd_aula"].ToString()!),
                            reader["titulo_aula"].ToString(),
                            reader["descricao_aula"].ToString(),
                            reader["thumbnail_url"].ToString(),
                            reader["video_url"].ToString(),
                            DateTime.Parse(reader["data_aula"].ToString()!)
                        ));
                }

                fConnection.Close();
                return lista;

            }
            catch (Exception e)
            {

                if (fConnection.State == System.Data.ConnectionState.Open)
                    fConnection.Close();
                return null!;

            }

        }

        internal static string DesableClass(int pIdClass)
        {
            try
            {
                fConnection.Open();
                MySqlCommand lQry = new MySqlCommand(ClassSQL.updateClass, fConnection);
                lQry.Parameters.AddWithValue("@idAula", pIdClass);

                lQry.ExecuteNonQuery();
                fConnection.Close();
                return $"Aula desativado com sucesso!";
            }
            catch (Exception e)
            {

                if (fConnection.State == System.Data.ConnectionState.Open)
                    fConnection.Close();
                return e.Message;
            }
        }


        public int? Id { get => id; set => id = value; }
        public string? Title { get => title; set => title = value; }
        public string? Description { get => description; set => description = value; }
        public string? Thumbnail { get => thumbnail; set => thumbnail = value; }
        public string? Video { get => video; set => video = value; }
        public DateTime? Date { get => date; set => date = value; }
        public int? Id_user_class { get => id_user_class; set => id_user_class = value; }
        public int? Id_category_class { get => id_category_class; set => id_category_class = value; }
        public string? PierSitReg { get => pierSitReg; set => pierSitReg = value; }
    }
}
