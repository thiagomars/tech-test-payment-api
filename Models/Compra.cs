using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tech_test_payment_api.Models
{
    [Table("compra")]
    public class Compra
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column ("id_venda")]
        public int VendaId { get; set; }

        public Venda Venda { get; set; }

        [Column ("id_itens")]
        public int ItensId { get; set; }

        public Itens Itens { get; set; }
    }
}
