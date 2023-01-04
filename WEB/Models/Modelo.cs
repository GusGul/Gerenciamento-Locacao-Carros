using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("Modelos")]
    public class Modelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("modelo_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Column("nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }

        public ICollection<Carro>? Carros { get; set; }
    }
}
