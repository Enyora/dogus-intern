using Microsoft.AspNetCore.Mvc;
using Product.API.Data.Repositories;
using System.Linq;

namespace Product.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IBaseRepo _repository;        //Get Repository

        public ClientsController(IBaseRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _repository.GetClients();
            if (!clients.Any()) //todo: hiç client yoksa
            {
                return NotFound();
            }

            return Ok(clients);
        }
    }
}
