using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<Client>().ToTable("Client");
        }

        public DbSet<WebPorfolioGenerator.Models.User> User { get; set; }

    }
}
