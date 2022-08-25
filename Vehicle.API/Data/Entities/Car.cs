using System.ComponentModel.DataAnnotations;

namespace Vehicle.API.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
    }
}
