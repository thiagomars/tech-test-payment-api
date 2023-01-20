using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tech_test_payment_api.Models
{
    [Table("vendedor")]
    public class Vendedor
    {
        [Key]
        [Column ("id")]
        public int Id { get; set; }

        [Column("cpf")]
        public int Cpf { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public int Telefone { get; set; }
    }
}
