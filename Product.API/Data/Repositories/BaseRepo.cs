using Product.API.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Product.API.Data.Repositories
{
    public class BaseRepo : IBaseRepo
    {
        private readonly DataContext _context;

        public BaseRepo(DataContext context)
        {
            _context = context;
        }

        public List<Client> GetClients()
        {
            var clients = _context.Clients.ToList();
            return clients;
        }
    }
}