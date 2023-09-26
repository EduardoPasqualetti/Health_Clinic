using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public Guid IdStatus { get; set; } 

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Status da Consulta obrigatório!")]
        public string? StatusConsulta { get; set; }
    }
}
