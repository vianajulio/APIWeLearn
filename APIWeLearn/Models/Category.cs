using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace APIWeLearn.Models {
    public class Category {
        //static MySqlConnection fConection = new MySqlConnection(
        //   "server=welearndb.mariadb.database.azure.com;database=mydb;user id=welearnadmin@welearndb; password=Password?");


        //const string cSqlInsertClass = "INSERT INTO catogorias(nome_catogoria, descricao_Category, pier_sit_reg)" +
        //    "VALUES(@name, @description, 'ATV')";

        //const string cSqlSearchCategory = "SELECT * FROM catogorias WHERE id_catogoria = @idCategory";

        static MySqlConnection fConection = new MySqlConnection(CategorySQL.connectiondb);

        private int id;
        private string? name;
        private string? description;
        private string? pierSitReg;

        public Category(int id, string? name, string? description, string? pierSitReg) {
            this.Id = id;
            this.Name = name!;
            this.Description = description!;
            this.PierSitReg = pierSitReg!;
        }

        [JsonConstructor]
        public Category(string? name, string? description) {
            this.Name = name!;
            this.Description = description!;
            pierSitReg = "ATV";
        }

        internal string InsertCategory() {
            try {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(CategorySQL.insertCategory, fConection);
                lQry.Parameters.AddWithValue("@name", this.name);
                lQry.Parameters.AddWithValue("@description", this.description);

                lQry.ExecuteNonQuery();
                fConection.Close();
                return $"Category {this.name} cadastrada com sucesso!";

            }
            catch (Exception e) {

                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return e.Message;
            }
        }

        internal static Category SearchCategory(int pIdCategory) {
            try {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(CategorySQL.searchCategory, fConection);
                lQry.Parameters.AddWithValue("@idCategory", pIdCategory);

                Category category = null;

                MySqlDataReader reader = lQry.ExecuteReader();

                if (reader.Read()) {
                    category = new Category(int.Parse(reader["id_categoria"].ToString()!),
                        reader["nome_categoria"].ToString(),
                        reader["descricao_categoria"].ToString(),
                        reader["pier_sit_reg"].ToString()
                        );
                }
                fConection.Close();
                return category!;
            }
            catch (Exception e) {

                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return null!;
            }
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name!; set => name = value; }
        public string Description { get => description!; set => description = value; }
        public string PierSitReg { get => pierSitReg!; set => pierSitReg = value; }
    }
}
