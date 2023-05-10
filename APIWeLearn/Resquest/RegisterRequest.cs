namespace APIWeLearn.Resquest
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
