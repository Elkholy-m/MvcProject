using FirstWebApp.Models;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Item Entity
            modelBuilder.Entity<Item>().HasKey(x => x.Id);
            modelBuilder.Entity<Item>().Property(x => x.Name).HasMaxLength(30);
            modelBuilder.Entity<Item>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Item>().Property(x => x.Created).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Item>().HasOne<Category>("Category");

            // Category Entity
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Category>().HasMany<Item>("Items");
            modelBuilder.Entity<Category>().HasData
                (
                    new Category { Id = 1, Name = "Select Category" },
                    new Category { Id = 2, Name = "Computer" },
                    new Category { Id = 3, Name = "Mobile Phone" },
                    new Category { Id = 4, Name = "Electric Machine" }
                );
        }
        public DbSet<Item> items { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
