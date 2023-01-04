using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pedido_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Id do carro é obrigatório.")]
        [Column("carro_id")]
        public int CarroId { get; set; }

        [Required(ErrorMessage = "Data de alocação é obrigatória.")]
        [Column("data_alocacao", TypeName = "DATETIME")]
        public DateTime DataLocacao { get; set; }

        [Required(ErrorMessage = "Data de entrega é obrigatória.")]
        [Column("data_entrega", TypeName = "DATETIME")]
        public DateTime DataEntrega { get; set; }
    }
}
