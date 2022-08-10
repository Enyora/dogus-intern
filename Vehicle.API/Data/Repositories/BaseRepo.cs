using Vehicle.API.Controllers;
using Vehicle.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle.API.Data.Repositories{
    public class BaseRepo : IBaseRepo
    {
        private readonly DataContext _context;
         public BaseRepo(DataContext context)
        {
            _context = context;
        }
        public List<Car> GetCars()
        {
            var cars = _context.Cars.ToList();
            return cars;
        }

    }

}