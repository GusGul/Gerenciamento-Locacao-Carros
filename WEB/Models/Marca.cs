using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("Marcas")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("marca_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Column("nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }

        //[NotMapped]
        public ICollection<Carro>? Carros { get; set; }
        public ICollection<Modelo>? Modelos { get; set; }
    }
}
