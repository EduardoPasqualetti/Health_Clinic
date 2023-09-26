using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Health_Clinic.Domains
{
    [Table("Comentario")]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } 

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Inválido!")]
        public string? Descricao { get; set; }

        [Column(TypeName ="BIT")]
        [Required(ErrorMessage = "Exibicão do Comentário obrigatória!")]
        public bool Exibir { get; set; }

        [Required(ErrorMessage = "Consulta obrigatória!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
