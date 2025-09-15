using System.ComponentModel.DataAnnotations;

namespace WellnessHub.Models
{
    public class EstadoDeAnimo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Usuario { get; set; } = string.Empty;

        [Required]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = string.Empty; // Ej: Feliz, Triste, Neutral

        [Range(0, 10)]
        public int Energia { get; set; }

        [Range(0, 24)]
        public int HorasDeSueno { get; set; }

        [Range(0, 10)]
        public int NivelDeEstres { get; set; }
    }
}
