using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vehicle.API.Data.Entities;
using Vehicle.API.Data.Repositories;

namespace Vehicle.API.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()

        {
            var cars = await _vehicleRepository.GetCarsAsync();

            return View(cars);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            await _vehicleRepository.AddCarAsync(car);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(int id)
        {
            bool succedeed = await _vehicleRepository.DeleteCarAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var vehicle = await _vehicleRepository.GetCarByIdAsync(id);
            if(vehicle == null)
            {
                return RedirectToAction(nameof(Index)); 
            }

            return View(vehicle);
        }

        [HttpPost]

        public async Task<IActionResult> Update(Car car)
        {
            bool succedeed = await _vehicleRepository.UpdateCarAsync(car);

            return RedirectToAction(nameof(Index));
        }


    }
}
