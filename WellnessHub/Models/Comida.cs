using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WellnessHub.Models
{
    public class Comida
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Proteina { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Carbohidratos { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Grasas { get; set; }

        public int Calorias { get; set; }
    }
}