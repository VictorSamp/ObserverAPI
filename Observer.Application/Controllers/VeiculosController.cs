using Microsoft.AspNetCore.Mvc;
using ObserverAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObserverAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly ObserverDbContext _context;

        public VeiculosController(ObserverDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoViewModel>>> GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoViewModel>> GetById(long id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> Post([FromBody] AddVeiculoInputModel model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] UpdateVeiculoInputModel model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            return Ok();
        }
    }
}