using Microsoft.EntityFrameworkCore;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.DAL
{
    public class WebPortfolioContext : DbContext
    {       

       

        public WebPortfolioContext(DbContextOptions<WebPortfolioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
      
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\;Server=tcp:webportfoliogenerator.database.windows.net,1433;Initial Catalog=WebPortfolioGenerator;Persist Security Info=False;User ID=eva;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}

        public DbSet<User> Users { get; set; }
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<Employee> Employees { get; set; }
    }
}

