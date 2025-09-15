using Microsoft.EntityFrameworkCore;
using WellnessHub.Models;
using WellnessHubApi.Models;
namespace WellnessHub.Data
{
    public class WellnessHubContext : DbContext
    {
        public WellnessHubContext(DbContextOptions<WellnessHubContext> options) : base(options) { }

        public DbSet<Comida> Comidas { get; set; }
        public DbSet<Workout> Workouts { get; set; } 
        public DbSet<EstadoDeAnimo> EstadosDeAnimo { get; set; }
    }
}