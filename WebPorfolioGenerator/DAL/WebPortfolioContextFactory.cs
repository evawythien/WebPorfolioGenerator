using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebPorfolioGenerator.DAL
{
    public class WebPortfolioContextFactory : IDesignTimeDbContextFactory<WebPortfolioContext>
    {
        public WebPortfolioContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            DbContextOptionsBuilder<WebPortfolioContext> builder = new DbContextOptionsBuilder<WebPortfolioContext>();
            builder.UseSqlServer(connectionString);

            return new WebPortfolioContext(builder.Options);
        }
    }
}
