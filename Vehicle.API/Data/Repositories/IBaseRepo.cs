using Vehicle.API.Controllers;
using Vehicle.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vehicle.API.Data.Repositories{
     public interface IBaseRepo
    {
        List<Car> GetCars();
    }

}