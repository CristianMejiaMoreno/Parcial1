using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial1_CristiaMejia_JuanHerrera.Models
{
    public class ClienteDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(25)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
