using Product.API.Controllers;
using Product.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Data.Repositories
{
    public interface IBaseRepo
    {
        List<Client> GetClients();

        Task DeleteClients(int id);

         Task UpdateClient(Client element);

         Task AddClient(Client element);
    }
}
