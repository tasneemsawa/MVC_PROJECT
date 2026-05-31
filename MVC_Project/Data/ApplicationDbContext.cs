using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ASP14_EF;User Id=sa;Password=Password123;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Mobiles" },
                new Category() { Id = 2, Name = "Tablets" },
                new Category() { Id = 3, Name = "Laptops" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Product 1", Description = "this product 1", Price = 300, Quantity = 100, Rate = 0, CategoryId = 1 },
                new Product() { Id = 2, Name = "Product 2", Description = "this product 2", Price = 100, Quantity = 55, Rate = 0, CategoryId = 1 },
                new Product() { Id = 3, Name = "Product 2", Description = "this product 2", Price = 200, Quantity = 20, Rate = 0, CategoryId = 1 }
            );
        }

    }
}

