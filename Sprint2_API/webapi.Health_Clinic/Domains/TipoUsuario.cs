using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } 

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Titulo Obrigatório!")]
        public string? Titulo { get; set; }
    }
}
