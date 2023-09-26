using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("MedicoEspecialidade")]
    public class MedicoEspecialidade
    {
        [Key]
        public Guid IdMedicoEspecialidade { get; set; }


        [Required(ErrorMessage = "Medico obrigatório!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "Especialidade obrigatório!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }
    }
}
