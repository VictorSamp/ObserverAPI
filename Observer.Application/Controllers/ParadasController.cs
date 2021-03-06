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
    public class ParadasController : ControllerBase
    {
        private readonly ObserverDbContext _context;

        public ParadasController(ObserverDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParadaViewModel>>> GetAll()
        {
            var paradas = await _context.Paradas.ToListAsync();

            var paradaViewModel = paradas
                .Select(p => new ParadaViewModel(p.Id, p.Nome, p.Latitude, p.Longitude))
                .ToList();

            return Ok(paradaViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParadaViewModel>> GetById(long id)
        {
            var parada = await _context.Paradas
                .SingleOrDefaultAsync(p => p.Id == id);

            if (parada == null)
            {
                return NotFound();
            }

            var paradaViewModel = new ParadaViewModel(
                parada.Id,
                parada.Nome,
                parada.Latitude,
                parada.Longitude);

            return Ok(paradaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddParadaInputModel model)
        {
            var parada = new Parada(
                model.Nome,
                model.Latitude,
                model.Longitude);

            _context.Paradas.Add(parada);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                    nameof(GetById),
                    new { id = parada.Id },
                    parada
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateParadaInputModel>> Put(long id, [FromBody] UpdateParadaInputModel model)
        {
            var parada = await _context.Paradas
                .SingleOrDefaultAsync(p => p.Id == id);

            if (parada == null)
            {
                return NotFound();
            }

            parada.UpdateParada(
                model.Nome,
                model.Latitude,
                model.Longitude);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Parada>> Delete(long id)
        {
            var parada = await _context.Paradas
                .FindAsync(id);

            if (parada == null)
            {
                return NotFound();
            }

            _context.Paradas.Remove(parada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParadaExists(long id)
        {
            var parada = _context.Paradas.Any(p => p.Id == id);
            return parada;
        }
    }
}