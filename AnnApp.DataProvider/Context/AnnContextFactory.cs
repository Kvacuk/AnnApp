using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            optionBuilder.UseSqlServer(connectionString,b=>b.MigrationsAssembly("AnnApp.Core"));
            return new AnnContext(optionBuilder.Options);
        }
    }
}
