using Microsoft.EntityFrameworkCore;

namespace DbService.DataBase.Users
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
