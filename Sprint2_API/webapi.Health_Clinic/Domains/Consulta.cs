using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("Consulta")]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; }

        [Column(TypeName ="DATETIME")]
        [Required(ErrorMessage ="Data da Consulta obrigatoria")]
        public DateTime Data { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage ="Horário da Consulta obrigatório!")]
        public TimeSpan Horario { get; set; }


        [Required(ErrorMessage = "Informe o Médico!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public MedicoEspecialidade? Medico { get; set; }


        [Required(ErrorMessage = "Informe o Paciente!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }


        [Required(ErrorMessage = "Informe o Status da Consulta!")]
        public Guid IdStatus { get; set; }

        [ForeignKey(nameof(IdStatus))]
        public Status? Status { get; set; }
    }
}
