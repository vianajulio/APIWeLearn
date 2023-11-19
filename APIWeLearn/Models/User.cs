using APIWeLearn.Controllers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace APIWeLearn.Models
{
    public class User
    {
        static MySqlConnection fConection = new MySqlConnection(UserSQL.connectiondb);

        private int? id;
        private string? name;
        private string? email;
        private string? password;
        private string? userType;
        private DateTime? registerDate;
        private string? status;

        public User() { }
        public User(string email) {
            this.email = email;
        }
        public User(string email, string senha, string userType)
        {
            this.email = email;
            this.password = senha;
            this.userType = userType;
        }
        public User(string name, string email, string senha, string userType)
        {
            this.name = name;
            this.email = email;
            this.password = senha;
            this.userType = userType;
        }
        public User(string name, string email, string senha, string userType, string status)
        {
            this.name = name;
            this.email = email;
            this.password = senha;
            this.userType = userType;
            this.status = status;
        }

        internal bool InsertUser()
        {
            try
            {
                fConection.Open();
                MySqlCommand lQuery = new MySqlCommand(UserSQL.insertUser, fConection);
                lQuery.Parameters.AddWithValue("@name", this.name);
                lQuery.Parameters.AddWithValue("@email", this.email);
                lQuery.Parameters.AddWithValue("@password", this.password);
                lQuery.Parameters.AddWithValue("@userType", this.userType);
                lQuery.Parameters.AddWithValue("@data", DateTime.Now);

                lQuery.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { fConection.Close(); }
        }

        internal User? SearchUser()
        {
            try
            {
                User user = new User();
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(UserSQL.searchUser, fConection);
                lQry.Parameters.AddWithValue("@email", this.email);

                MySqlDataReader reader = lQry.ExecuteReader();

                if (reader.Read())
                {
                    user.id = reader.GetInt32("userID");
                    user.name = reader.GetString("userName");
                    user.email = reader.GetString("userEmail");
                    user.UserType = reader.GetString("userType");
                    user.registerDate = reader.GetDateTime("userRegisterDate");
                    user.status = reader.GetString("userStatus");
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                fConection.Close();
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
                    this.id = reader.GetInt32("userID");
                    this.name = reader.GetString("userName");
                    this.email = reader.GetString("userEmail");
                    this.password = reader.GetString("userPassword");
                    this.UserType = reader.GetString("userType");
                    this.registerDate = reader.GetDateTime("userRegisterDate");
                    this.status = reader.GetString("userStatus");
                }

            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                fConection.Close();
            }
        }


        internal bool EditUser()
        {
            try
            {
                fConection.Open();
                MySqlCommand lQry = new MySqlCommand(UserSQL.editUser, fConection);

                lQry.Parameters.AddWithValue("@userName", this.name);
                lQry.Parameters.AddWithValue("@userPassword", this.password);
                lQry.Parameters.AddWithValue("@userStatus", this.status);
                lQry.Parameters.AddWithValue("@userType", this.userType);

                lQry.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally { fConection.Close(); }
        }

        public int? Id { get => id; }
        public string? Name { get => name; set => name = value; }
        public string? Email { get => email; set => email = value; }
        public string? Password { get => password; set => password = value; }
        public string? UserType { get => userType; set => userType = value; }
        public DateTime? RegisterDate { get => registerDate; set => registerDate = value; }
        public string? Status { get => status; set => status = value; }


    }
}
