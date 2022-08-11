using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vehicle.API.Data.Entities;
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
        
        [HttpPost]

        public async Task<ActionResult> AddCar([FromBody] Car car)
        {
            await _repository.AddCar(car);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCar([FromBody] Car car)
        {
            await _repository.UpdateCar(car);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(int id)
        {
            await _repository.DeleteCar(id);
            return NoContent();
        }

              [HttpGet("{id}")]

        public ActionResult GetCarById(int id)
        {
            var car = _repository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(car);
            }
        }
    }

}
