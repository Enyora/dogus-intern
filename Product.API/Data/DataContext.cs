using Microsoft.EntityFrameworkCore;
using Product.API.Data.Entities;

namespace Product.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
        }
        public DbSet<Client> Clients { get; set; }
    }
    
}
