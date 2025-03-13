using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial1_CristiaMejia_JuanHerrera.Models
{
    public class TipoViviendaDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoVivienda { get; set; }
        [Required]  
        [StringLength(50)]
        public string Descripcion { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
