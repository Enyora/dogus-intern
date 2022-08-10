using Microsoft.EntityFrameworkCore;
using Vehicle.API.Data.Entities;

namespace Vehicle.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
        }
        public DbSet<Car> Cars { get; set; }
    }
    
}