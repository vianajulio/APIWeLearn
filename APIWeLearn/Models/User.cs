using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace APIWeLearn.Models {
    public class User 
    {
        //static MySqlConnection fConection = new MySqlConnection(
        //    "server=localhost;database=we_learn_db;user id=root; password=");


        //const string cSqlInsertUser = "INSERT INTO usuarios(nome_usuario, email, senha, tipo_usuario, data_cadastro, pier_sit_reg)" +
        //            "VALUES(@name, @email, @password, @userType, @data, 'ATV')";

        //const string cSqlSeachUsers = "SELECT * FROM usuarios WHERE id_usuario = @id_usuario";

        //const string cSqlEditUser = "UPDATE usuarios SET nome_usuario = @userName, senha = @userPassword, pier_sit_reg = @pierSitReg WHERE id_usuario = @idUser";

        static MySqlConnection fConection = new MySqlConnection(UserSQL.connectiondb);

        private int? id;
        private string? name;
        private string? email;
        private string? password;
        private int? userType;
        private DateTime? registerDate;
        private string? pierSitReg;

        [JsonConstructor]
        public User(string? name = "", string? email = "", string? senha = "", int? userType = 1) {
            this.name = name;
            this.email = email;
            this.password = senha;
            this.userType = userType;
            registerDate = DateTime.Now;
            pierSitReg = "ATV";
        }

        public User(int? id, string? name, string? email, string? senha, int? userType, DateTime? registerDate, string? pierSitReg) {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = senha;
            this.userType = userType;
            this.registerDate = registerDate;
            this.pierSitReg = pierSitReg;
        }

        internal string InsertUser() {
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
                return $"Usuário {this.name} cadastrado com sucesso!";

            }
            catch (Exception e) {
                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return e.Message;
            }
        }

        internal void SearchUser() {
            try {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(UserSQL.searchUser, fConection);
                lQry.Parameters.AddWithValue("@email", this.email);
                lQry.Parameters.AddWithValue("@password", this.password);

                MySqlDataReader reader = lQry.ExecuteReader();

                if (reader.Read()) {
                    this.id = int.Parse(reader["id_usuario"].ToString()!);
                    this.name = reader["nome_usuario"].ToString()!;
                    this.email = reader["email"].ToString()!;
                    this.password = ""; //reader["senha"].ToString()!;
                    this.UserType = int.Parse(reader["tipo_usuario"].ToString()!);
                    this.registerDate = DateTime.Parse(reader["data_cadastro"].ToString()!);
                    this.pierSitReg = reader["pier_sit_reg"].ToString()!;
                }
                fConection.Close();

            }
            catch (Exception e) {
                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
            }
        }

        internal string EditUser() {
            try {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(UserSQL.editUser, fConection);
                lQry.Parameters.AddWithValue("@userName", this.name);
                lQry.Parameters.AddWithValue("@userPassword", this.password);
                lQry.Parameters.AddWithValue("@pierSitReg", this.pierSitReg);
                lQry.Parameters.AddWithValue("@idUser", this.id);

                lQry.ExecuteNonQuery();
                fConection.Close();
                return $"Usuário {this.name} editado com sucesso!";
            }
            catch (Exception e) {

                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return e.Message;
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
