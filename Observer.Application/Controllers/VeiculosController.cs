using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObserverAPI.Data;
using ObserverAPI.Entities;
using ObserverAPI.Models.InputModels;
using ObserverAPI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
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
            var veiculos = await _context.Veiculos.ToListAsync();

            var veiculoViewModel = veiculos
                .Select(v => new VeiculoViewModel(v.Id, v.Nome, v.Modelo, v.LinhaId))
                .ToList();

            return Ok(veiculoViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoViewModel>> GetById(long id)
        {
            var veiculo = await _context.Veiculos
                .SingleOrDefaultAsync(v => v.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            var veiculoViewModel = new VeiculoViewModel(veiculo.Id, veiculo.Nome, veiculo.Modelo, veiculo.LinhaId);

            return Ok(veiculoViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddVeiculoInputModel model)
        {
            var veiculo = new Veiculo(model.Nome, model.Modelo);

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = veiculo.Id },
                veiculo
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] UpdateVeiculoInputModel model)
        {
            var veiculo = await _context.Veiculos
                .SingleOrDefaultAsync(v => v.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            veiculo.UpdateVeiculo(model.Nome, model.Modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var veiculo = await _context.Veiculos
                .SingleOrDefaultAsync(v => v.Id == id);

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}