using System.Text.Json.Serialization.Metadata;

namespace APIWeLearn.Controllers
{
    public class UserEditResquest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserStatus { get; set; }
        public string UserType { get; set; }
    }
}
