using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace APIWeLearn.Models {
    public class Category {
        static MySqlConnection fConection = new MySqlConnection(CategorySQL.connectiondb);

        private int? id;
        private string? name;
        private string? description;
        private string? pierSitReg;

        public Category() { }
        public Category(int? id, string? name, string? description, string? pierSitReg) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.pierSitReg = pierSitReg;
        }
        public Category(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        internal bool InsertCategory() {
            try {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(CategorySQL.insertCategory, fConection);
                lQry.Parameters.AddWithValue("@name", this.name);
                lQry.Parameters.AddWithValue("@description", this.description);

                lQry.ExecuteNonQuery();
                return true;

            }
            catch (Exception e) {

                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return false;
            }
            finally { fConection.Close(); }
        }

        internal static List<Category> getCategory() {
            try {
                List<Category> categories = new List<Category>();

                fConection.Open();

                MySqlCommand lQry = new MySqlCommand(CategorySQL.getCategory, fConection);
                MySqlDataReader reader = lQry.ExecuteReader();

                while (reader.Read())
                {
                    Category category = new Category();

                    category.id = reader.GetInt32("id_categoria");
                    category.name = reader.GetString("nome_categoria");
                    category.description = reader.GetString("descricao_categoria");
                    category.pierSitReg = reader.GetString("pier_sit_reg");

                    categories.Add(category);
                }

                return categories;
            }
            catch (Exception e) {
                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                throw;
            }
            finally {
                fConection.Close();
            }
        }

        public int? Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }
        public string? Description { get => description; set => description = value; }
        public string? PierSitReg { get => pierSitReg; set => pierSitReg = value; }
    }
}
