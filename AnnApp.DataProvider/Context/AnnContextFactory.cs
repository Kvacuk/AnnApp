using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AnnApp.DataProvider.Context
{
    public class AnnContextFactory : IDesignTimeDbContextFactory<AnnContext>
    {
        public AnnContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AnnContext>();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            optionBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("AnnApp.DataProvider"));
            return new AnnContext(optionBuilder.Options);
        }
    }
}
