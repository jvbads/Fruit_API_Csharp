using FruitApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FruitApplication.DataAccess.Utils
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>(Entity => Entity.Property(e => e.Id).ValueGeneratedOnAdd());
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitType> FruitTypes { get; set; }
    }

}
