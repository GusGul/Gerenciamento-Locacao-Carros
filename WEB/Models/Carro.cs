using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("Carros")]
    public class Carro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("carro_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Column("nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Id da marca é obrigatório.")]
        [Column("marca_id")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Id do modelo é obrigatório.")]
        [Column("modelo_id")]
        public int ModeloId { get; set; }
    }
}
