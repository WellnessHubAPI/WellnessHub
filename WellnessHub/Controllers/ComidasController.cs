using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellnessHubApi.Data;
using WellnessHubApi.Models;

namespace WellnessHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly WellnessHubContext _context;

        public MealsController(WellnessHubContext context)
        {
            _context = context;
        }

        // GET: api/Meals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comida>>> GetComidas()
        {
            return await _context.Comidas.ToListAsync();
        }

        // GET: api/Meals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comida>> GetComida(int id)
        {
            var comida = await _context.Comidas.FindAsync(id);

            if (comida == null)
            {
                return NotFound();
            }

            return comida;
        }

        // POST: api/Meals
        [HttpPost]
        public async Task<ActionResult<Comida>> PostComida(Comida comida)
        {
            _context.Comidas.Add(comida);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComida), new { id = comida.Id }, comida);
        }

        // PUT: api/Meals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComida(int id, Comida comida)
        {
            if (id != comida.Id)
            {
                return BadRequest();
            }

            _context.Entry(comida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Comidas.Any(e => e.Id == id))
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

        // DELETE: api/Meals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComida(int id)
        {
            var comida = await _context.Comidas.FindAsync(id);
            if (comida == null)
            {
                return NotFound();
            }

            _context.Comidas.Remove(comida);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}