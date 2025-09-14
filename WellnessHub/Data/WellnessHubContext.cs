using Microsoft.EntityFrameworkCore;
using WellnessHubApi.Models;

namespace WellnessHubApi.Data
{
    public class WellnessHubContext : DbContext
    {
        public WellnessHubContext(DbContextOptions<WellnessHubContext> options) : base(options) { }

        public DbSet<Comida> Comidas { get; set; }
    }
}