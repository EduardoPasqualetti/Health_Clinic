using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("Consulta")]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; }

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Data da Consulta obrigatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage ="Horário da Consulta obrigatório!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan Horario { get; set; }


        [Required(ErrorMessage = "Informe o Médico!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }


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
