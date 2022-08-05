using Microsoft.EntityFrameworkCore;
using Product.API.Data.Entities;

namespace Product.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
