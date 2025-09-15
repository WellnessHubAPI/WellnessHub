using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellnessHubApi.Data;
using WellnessHubApi.Models;

namespace WellnessHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Workouts : ControllerBase
    {
        private readonly WellnessHubContext _context;

        public Workouts(WellnessHubContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // POST: api/Workouts
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkout), new { id = workout.Id }, workout);
        }

        // PUT: api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Workouts.Any(e => e.Id == id))
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

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
