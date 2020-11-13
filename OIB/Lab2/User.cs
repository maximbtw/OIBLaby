namespace OIB.Lab2
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        public virtual Profile Profile { get; set; }
    }
}
