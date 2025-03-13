using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial1_CristiaMejia_JuanHerrera.Models
{
    public class VentaDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta { get; set; }
        [ForeignKey("IdAgencia")]
        public virtual AgenciaDTO? Agencia { get; set; }
        public int IdAgencia { get; set; }
        [ForeignKey("IdCliente")]
        public virtual ClienteDTO? Cliente { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdVivienda")]
        public virtual ViviendaDTO? Vivienda { get; set; }
        public int IdVivienda { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
