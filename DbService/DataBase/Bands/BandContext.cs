using Microsoft.EntityFrameworkCore;

namespace DbService.DataBase.Bands
{
    public class BandContext: DbContext
    {
        public BandContext(DbContextOptions<BandContext> options)
       : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureCreated();
        }

        public DbSet<Band> Bands { get; set; }
    }
}
