using Dogus.Models;

namespace Client.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
  

        }
}
