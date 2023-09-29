using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic.Domains
{
    [Table("Clinica")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; }


        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ da Clínica obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço da Clínica obrigatório!")]
        public string? Endereco { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome Fantasia da Clínica obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Razão Social da Clínica obrigatório!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName ="TIME")]
        [Required(ErrorMessage = "Horário de Abertura da Clínica obrigatório!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan HorarioAbertura { get; set; }

        [Column(TypeName ="TIME")]
        [Required(ErrorMessage = "Horário de Fechamento da Clínica obrigatório!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan HorarioFechamento { get; set; }

    }
}
