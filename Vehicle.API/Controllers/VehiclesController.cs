using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.API.Data.Entities;
using Vehicle.API.Data.Repositories;

namespace Vehicle.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _repository;
        public VehiclesController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _repository.GetCarsAsync();
            if (cars is null || !cars.Any())
            {
                return NotFound();
            }

            return Ok(cars);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            bool succedeed = await _repository.AddCarAsync(car);
            if (!succedeed)
            {
                return BadRequest("istediğim tipte değil.");
            }

            return Ok();
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
            bool succedeed =  await _repository.UpdateCarAsync(car);
            if (!succedeed)
            {
                return BadRequest("güncelleme işlemi başarısız.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            bool succedeed = await _repository.DeleteCarAsync(id);
            if (!succedeed)
            {
                return BadRequest("silme işlemi başarısız.");
            }

            return NoContent();
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _repository.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound("aradıgın araç yok.");
            }
            else
            {
                return Ok(car);
            }
        }

        [HttpGet("{modelname}/{price}")]
        public async Task<IActionResult> GetConditional(string modelname, int price)
        {
            var cars =  await _repository.GetConditionalAsync(modelname,price);
             if (cars is null || !cars.Any())
            {
                return NotFound("aradıgın kriterde yok.");
            }
            else
            {
                return Ok(cars);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPrice()
        {
            var cars = await _repository.GetPriceAsync();
            if (cars == null)
            {
                return NotFound("Bu fiyat aralığında araç bulunamadı");
            }
            else
            {
                return Ok(cars);
            }
        }
    }
}
