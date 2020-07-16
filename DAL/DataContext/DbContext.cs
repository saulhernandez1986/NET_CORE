
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Jobs> Jobs { get; set; }

        public class OptionBuild
        {
            public OptionBuild()
            {
                settings = new AppConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(settings.SqlConnectionStrings);
                dbOptions = optionsBuilder.Options;
            }

            public DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder { get; set; }
            public DbContextOptions<ApplicationDbContext> dbOptions { get; set; }

            private AppConfiguration settings { get; set; }

        }

        public static OptionBuild ops = new OptionBuild();


    }
}
