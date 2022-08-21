using Microsoft.EntityFrameworkCore;

namespace FruitApplication
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FruitDTO>(Entity => Entity.Property(e => e.Id).ValueGeneratedOnAdd());
        }

        public DbSet<FruitDTO> Fruits { get; set; }
        public DbSet<FruitTypeDTO> FruitTypes { get; set; }
    }

}
