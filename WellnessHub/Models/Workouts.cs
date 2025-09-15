using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WellnessHubApi.Models
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string User { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "date")]
        public DateTime SessionDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Exercise { get; set; } = string.Empty;

        [Column(TypeName = "int")]
        public int DurationMinutes { get; set; }

        [Required]
        [MaxLength(50)]
        public string Intensity { get; set; } = string.Empty;

        [Column(TypeName = "int")]
        public int CaloriesBurned { get; set; }
    }
}