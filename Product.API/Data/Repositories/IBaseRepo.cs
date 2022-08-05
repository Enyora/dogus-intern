using Product.API.Data.Entities;
using System.Collections.Generic;

namespace Product.API.Data.Repositories
{
    public interface IBaseRepo
    {
        List<Client> GetClients();
    }
}
