using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tech_test_payment_api.Models
{
    [Table("itens")]
    public class Itens
    {
        [Key]
        [Column ("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }
    }
}