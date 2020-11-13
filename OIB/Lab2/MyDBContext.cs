using System.Data.Entity;

namespace OIB.Lab2
{
    class MyDBContext : DbContext
    {
        public MyDBContext() : base("DBOIBConection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> UserProfiles { get; set; }
    }
}
