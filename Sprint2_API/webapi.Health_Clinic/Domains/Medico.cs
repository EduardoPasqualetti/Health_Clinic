using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("Medico")]
    public class Medico
    {
        [Key]
        public Guid? IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do Medico obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="CRM obrigatório!")]
        public string? CRM { get; set; }


        [Required(ErrorMessage = "Informe o Usuario")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage ="Informe a Clínica")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
