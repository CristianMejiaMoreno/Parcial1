using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial1_CristiaMejia_JuanHerrera.Models
{
    public class ViviendaDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVivienda { get; set; }
        [ForeignKey("IdAgencia")]
        public virtual AgenciaDTO? Agencia { get; set; }
        public int IdAgencia { get; set; }
        [ForeignKey("IdTipoVivienda")]
        public virtual TipoViviendaDTO? TipoVivienda { get; set; }
        public int IdTipoVivienda { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El numero de cuartos debe ser mayor que 0.")]
        public int NumeroCuartos { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El numero de baños debe ser mayor que 0.")]
        public int NumeroBanos { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Los m2 del inmueble deben ser mayor que 0.")]
        public int TamanoM2 { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El numero de pisos del inmueble debe ser mayor que 0.")]
        public int NumeroPisos { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Accesorios { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
