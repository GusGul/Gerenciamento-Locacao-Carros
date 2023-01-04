using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cliente_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Column("nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Column("email", TypeName = "varchar(155)")]
        public string Email { get; set; }

        [Column("telefone", TypeName = "varchar(155)")]
        public string Telefone { get; set; }

        [Column("endereco", TypeName = "text")]
        public string Endereco { get; set; }
    }
}
