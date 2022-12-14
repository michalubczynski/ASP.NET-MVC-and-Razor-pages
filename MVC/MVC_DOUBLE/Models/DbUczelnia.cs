using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MVC_DOUBLE.Models;

namespace MVC_DOUBLE.Models
{
    public class DbUczelnia : DbContext
    {
        public ICollection<Student> Studenci { get; set; }
        public ICollection<Grupa> Grupy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Uczelnia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<MVC_DOUBLE.Models.Grupa> Grupa { get; set; }
    }
}
