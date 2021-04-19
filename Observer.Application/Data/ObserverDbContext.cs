using Microsoft.EntityFrameworkCore;
using ObserverAPI.Entities;
using System.Reflection;

namespace ObserverAPI.Data
{
    public class ObserverDbContext : DbContext
    {
        public ObserverDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Linha> Linhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}