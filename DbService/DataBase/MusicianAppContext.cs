using Microsoft.EntityFrameworkCore;
namespace DbService.DataBase
{
    public class MusicianAppContext: DbContext
    {
        public MusicianAppContext(DbContextOptions<MusicianAppContext> options)
       : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Band> Bands { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>(b =>
            {
                b.HasMany(b => b.Users)
                .WithMany(u => u.Bands).
                UsingEntity(e => { e.ToTable("BandsUsers"); });
            });
        }
    }
}
