using LevelUpDb3.Desktop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LevelUpDb3.Desktop.Models
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use the connection string to connect to the SQL Server database
                optionsBuilder.UseSqlServer("Server=localhost;Database=LevelUpDb3;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
                configurationBuilder.Properties<string>().AreUnicode(false);
                configurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
                configurationBuilder.Properties<Decimal>().HavePrecision(18, 2);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
