using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Data
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ASP14_EF;User Id=sa;Password=Password123;TrustServerCertificate=True");
        }

    }
}

