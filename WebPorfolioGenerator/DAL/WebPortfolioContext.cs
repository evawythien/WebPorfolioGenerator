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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().ToTable("Users");
        //    modelBuilder.Entity<Client>().ToTable("Clients");
        //    modelBuilder.Entity<Employee>().ToTable("Employees");
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


