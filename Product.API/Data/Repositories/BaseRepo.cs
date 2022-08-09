using Product.API.Controllers;
using Product.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Product.API.Data.Repositories
{

    public class BaseRepo : IBaseRepo
    {
        private readonly DataContext _context;

        public BaseRepo(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteClients(int id)
        {
                 if(id != 0)
            {
                _context.Clients.Remove(new Client
                {
                    Id = id,
                });

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public List<Client> GetClients()
        {
            var clients = _context.Clients.ToList();
            return clients;
        }
        public Task DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateClient(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task AddClient(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
        }

    }
}