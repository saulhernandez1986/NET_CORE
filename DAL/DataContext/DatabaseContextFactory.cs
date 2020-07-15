using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.DataContext
{
    class DatabaseContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer(appConfig.SqlConnectionStrings);
            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
