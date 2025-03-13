using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Parcial1_CristiaMejia_JuanHerrera.Models
{
    public class AgenciaDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgencia { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(255)]
        public string Direccion { get; set; }
        [StringLength(15)]
        public string Telefono { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
