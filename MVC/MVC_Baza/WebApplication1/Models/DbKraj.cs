using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebApplication1.Models
{
    public class DbKraj : DbContext
    {
        public DbSet<Wojewodztwo> Wojewodztwa { get; set; }
        public DbSet<Miasto> Miasta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kraj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
