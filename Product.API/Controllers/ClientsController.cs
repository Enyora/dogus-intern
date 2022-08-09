using Microsoft.AspNetCore.Mvc;
using Product.API.Data.Entities;
using Product.API.Data.Repositories;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClients(int id)
        {
            await _repository.DeleteClients(id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClient([FromBody] Client client)
        {
            await _repository.UpdateClient(client);
            return NoContent();
        }

        [HttpPost]

        public async Task<ActionResult> AddClient([FromBody] Client client)
        {
            await _repository.AddClient(client);
            return NoContent();
        }

    }
}
