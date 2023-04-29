using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

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
        public User(string? name, string? email, string? senha, int? userType) {
            this.name = name;
            this.email = email;
            this.password = senha;
            this.userType = userType;
            registerDate = DateTime.Now;
            pierSitReg = "ATV";
        }

        public User(int? id, string? name, string? email, string? senha, int? userType, DateTime registerDate, string pierSitReg) {
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

        internal static User SearchUser(int pIdUser) {
            try {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(UserSQL.searchUsers, fConection);
                lQry.Parameters.AddWithValue("@id_usuario", pIdUser);

                User user = null;

                MySqlDataReader reader = lQry.ExecuteReader();

                if (reader.Read()) {
                    user = new User(
                        int.Parse(reader["id_usuario"].ToString()!),
                        reader["nome_usuario"].ToString()!,
                        reader["email"].ToString()!,
                        reader["senha"].ToString()!,
                        int.Parse(reader["tipo_usuario"].ToString()!),
                        DateTime.Parse(reader["data_cadastro"].ToString()!),
                        reader["pier_sit_reg"].ToString()!
                        );
                }
                fConection.Close();
                return user!;

            }
            catch (Exception e) {
                if (fConection.State == System.Data.ConnectionState.Open)
                    fConection.Close();
                return null!;
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
