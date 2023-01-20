using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tech_test_payment_api.Models
{
    [Table("venda")]
    public class Venda
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("data")]
        public string Data { get; set; }
        [Column("status")]
        public EnumStatus Status { get; set; }

        [Column ("id_vendedor")]
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
