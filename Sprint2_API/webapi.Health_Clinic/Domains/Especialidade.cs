using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("Especialidade")]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; }


        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Título da Especialidade obrigatório!")]
        public string? Titulo { get; set; }
    }
}
