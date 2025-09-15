using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellnessHub.Data;
using WellnessHub.Models;

namespace WellnessHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosDeAnimoController : ControllerBase
    {
        private readonly WellnessHubContext _context;

        public EstadosDeAnimoController(WellnessHubContext context)
        {
            _context = context;
        }

        // GET: api/EstadosDeAnimo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDeAnimo>>> GetEstadosDeAnimo()
        {
            return await _context.EstadosDeAnimo.ToListAsync();
        }

        // GET: api/EstadosDeAnimo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoDeAnimo>> GetEstadoDeAnimo(int id)
        {
            var estadoDeAnimo = await _context.EstadosDeAnimo.FindAsync(id);

            if (estadoDeAnimo == null)
            {
                return NotFound();
            }

            return estadoDeAnimo;
        }

        // POST: api/EstadosDeAnimo
        [HttpPost]
        public async Task<ActionResult<EstadoDeAnimo>> PostEstadoDeAnimo(EstadoDeAnimo estadoDeAnimo)
        {
            _context.EstadosDeAnimo.Add(estadoDeAnimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstadoDeAnimo), new { id = estadoDeAnimo.Id }, estadoDeAnimo);
        }

        // PUT: api/EstadosDeAnimo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoDeAnimo(int id, EstadoDeAnimo estadoDeAnimo)
        {
            if (id != estadoDeAnimo.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoDeAnimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.EstadosDeAnimo.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/EstadosDeAnimo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoDeAnimo(int id)
        {
            var estadoDeAnimo = await _context.EstadosDeAnimo.FindAsync(id);
            if (estadoDeAnimo == null)
            {
                return NotFound();
            }

            _context.EstadosDeAnimo.Remove(estadoDeAnimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
