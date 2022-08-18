using FruitApplication.Entities;
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
            modelBuilder.Entity<FruitDTOModel>(Entity => Entity.Property(e => e.Id).ValueGeneratedOnAdd());
        }

        public DbSet<FruitDTOModel> Fruits { get; set; }
        public DbSet<FruitTypeModel> FruitTypes { get; set; }
    }

}
