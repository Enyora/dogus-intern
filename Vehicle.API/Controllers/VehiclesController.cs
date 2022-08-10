using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vehicle.API.Data.Repositories;

namespace Vehicle.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IBaseRepo _repository;
        public VehiclesController(IBaseRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _repository.GetCars();
            if (!cars.Any()) 
            {
                return NotFound();
            }

            return Ok(cars);
        }


    }
}
