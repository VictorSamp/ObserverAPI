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
    public class LinhasController : ControllerBase
    {
        private readonly ObserverDbContext _context;

        public LinhasController(ObserverDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinhaViewModel>>> GetAll()
        {
            var linhas = await _context.Linhas.ToListAsync();

            var linhaViewModel = linhas
                .Select(l => new LinhaViewModel(l.Id, l.Nome))
                .ToList();

            return Ok(linhaViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LinhaViewModel>> GetById(long id)
        {
            var linha = await _context.Linhas
                .Include(p => p.Paradas)
                .SingleOrDefaultAsync(l => l.Id == id);

            if (linha == null)
            {
                return NotFound();
            }

            var linhaViewModel = new LinhaViewModel(linha.Id, linha.Nome);

            return Ok(linhaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<AddLinhaInputModel>> Post([FromBody] AddLinhaInputModel model)
        {
            var linha = new Linha(model.Nome);

            _context.Linhas.Add(linha);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = linha.Id },
                linha
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateLinhaInputModel>> Put(long id, [FromBody] UpdateLinhaInputModel model)
        {
            var linha = await _context.Linhas
                .SingleOrDefaultAsync(l => l.Id == id);

            if (linha == null)
            {
                return NotFound();
            }

            linha.UpdateLinha(model.Nome);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Linha>> Delete(long id)
        {
            var linha = await _context.Linhas.SingleOrDefaultAsync(l => l.Id == id);

            if (linha == null)
            {
                return NotFound();
            }

            _context.Linhas.Remove(linha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{linhaId}/adicionar-parada/{paradaId}")]
        public async Task<ActionResult> AddParadaEmLinha(long linhaId, long paradaId)
        {
            var linha = await _context.Linhas
                .SingleOrDefaultAsync(l => l.Id == linhaId);

            if (linha == null)
            {
                return NotFound();
            }

            var parada = await _context.Paradas
                .SingleOrDefaultAsync(p => p.Id == paradaId);

            if (parada == null)
            {
                return NotFound();
            }

            linha.Paradas.Add(parada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{linhaId}/remover-parada/{paradaId}")]
        public async Task<ActionResult> DeleteParadaEmLinha(long linhaId, long paradaId)
        {
            var linha = await _context.Linhas
                .SingleOrDefaultAsync(l => l.Id == linhaId);

            if (linha == null)
            {
                return NotFound();
            }

            var parada = await _context.Paradas
                .SingleOrDefaultAsync(p => p.Id == paradaId);

            if (parada == null)
            {
                return NotFound();
            }

            linha.Paradas.Remove(parada);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}