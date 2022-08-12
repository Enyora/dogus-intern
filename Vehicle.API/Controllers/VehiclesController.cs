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

        //404, 200
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

        //200, 400
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

        //204, 400
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

        //200, 404
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

    }

}
