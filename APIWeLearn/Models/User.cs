using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace APIWeLearn.Models {
    public class User 
    {
        static MySqlConnection fConection = new MySqlConnection(UserSQL.connectiondb);

        private int? id;
        private string? name;
        private string? email;
        private string? password;
        private int? userType;
        private DateTime? registerDate;
        private string? pierSitReg;


        public User(DateTime? dateTime, int? id = 0, string? name = "", string? email = "", string? senha = "", int? userType = 1, string? pierSitReg = "ATV") {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = senha;
            this.userType = userType;
            this.registerDate = dateTime;
            this.pierSitReg = pierSitReg;
        }
        public User() { }


        internal bool InsertUser() {
            try {
                fConection.Open();
                MySqlCommand lQuery = new MySqlCommand(UserSQL.insertUser, fConection);
                lQuery.Parameters.AddWithValue("@name", this.name);
                lQuery.Parameters.AddWithValue("@email", this.email);
                lQuery.Parameters.AddWithValue("@password", this.password);
                lQuery.Parameters.AddWithValue("@userType", this.userType);
                lQuery.Parameters.AddWithValue("@data", this.registerDate);

                lQuery.ExecuteNonQuery();
                fConection.Close();
                return true;

            }
            catch (Exception e) {
                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return false;
            }
        }

        public User SearchUser() {
            try {
                User user = new User();
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(UserSQL.searchUser, fConection);
                lQry.Parameters.AddWithValue("@email", this.email);

                MySqlDataReader reader = lQry.ExecuteReader();

                if (reader.Read()) {
                    user.id = reader.GetInt32("id_usuario");
                    user.name = reader.GetString("nome_usuario");
                    user.email = reader.GetString("email");
                    user.UserType = reader.GetInt32("tipo_usuario");
                    user.registerDate = reader.GetDateTime("data_cadastro");
                    user.pierSitReg = reader.GetString("pier_sit_reg");
                } else
                {
                    return null;
                }
                fConection.Close();
                return user;
            }
            catch (Exception e) {
                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return null;
            }
        }

        public void LoginUser()
        
        {
            try
            {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(UserSQL.loginUser, fConection);
                lQry.Parameters.AddWithValue("@email", this.email);
                lQry.Parameters.AddWithValue("@password", this.password);

                MySqlDataReader reader = lQry.ExecuteReader();
                
                if (reader.Read())
                {
                    this.id = reader.GetInt32("id_usuario");
                    this.name = reader.GetString("nome_usuario");
                    this.email = reader.GetString("email");
                    this.password = reader.GetString("senha");
                    this.UserType = reader.GetInt32("id_usuario");
                    this.registerDate = reader.GetDateTime("data_cadastro") ;
                    this.pierSitReg = reader.GetString("pier_sit_reg");
                }
                fConection.Close();
            }
            catch (Exception e)
            {
                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
            }
        }


        internal bool EditUser() {
            try {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(UserSQL.editUser, fConection);
                lQry.Parameters.AddWithValue("@userName", this.name);
                lQry.Parameters.AddWithValue("@userPassword", this.password);
                lQry.Parameters.AddWithValue("@pierSitReg", this.pierSitReg);
                lQry.Parameters.AddWithValue("@idUser", this.id);

                lQry.ExecuteNonQuery();

                fConection.Close();
                return true;
            }
            catch (Exception e) {

                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return false;
            }
        }

        public int? Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }
        public string? Email { get => email; set => email = value; }
        public string? Password { get => password; set => password = value; }
        public int? UserType { get => userType; set => userType = value; }
        public DateTime? RegisterDate { get => registerDate; set => registerDate = value; }
        public string? PierSitReg { get => pierSitReg; set => pierSitReg = value; }


    }
}
