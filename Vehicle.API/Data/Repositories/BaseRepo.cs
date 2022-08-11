using Vehicle.API.Controllers;
using Vehicle.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.API.Data.Repositories{
    public class BaseRepo : IBaseRepo
    {
        private readonly DataContext _context;
         public BaseRepo(DataContext context)
        {
            _context = context;
        }

        public async Task AddCar(Car car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteCar(int id)
        {
           if(id != 0)
            {
            _context.Cars.Remove(new Car
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


        public Car GetCarById(int id)
        {
            var car = _context.Cars.Find(id);
            return car;
        }

        public List<Car> GetCars()
        {
            var cars = _context.Cars.ToList();
            return cars;
        }

        public async Task UpdateCar(Car car)
        {
           _context.Update(car);
           await _context.SaveChangesAsync();
        }

    }

}