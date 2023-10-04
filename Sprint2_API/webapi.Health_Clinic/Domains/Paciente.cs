using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do Paciente obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "CPF do Paciente obrigatório!")]
        public string? CPF { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "Telefone do Paciente obrigatório!")]
        public string? Telefone { get; set; }

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Data de Nascimento obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DataDeNascimento { get; set; }

        [Required(ErrorMessage ="Informe o Usuario")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
