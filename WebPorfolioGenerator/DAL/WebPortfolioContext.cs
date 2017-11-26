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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Font> Fonts { get; set; }
        public DbSet<Galery> Galerys { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }
}

