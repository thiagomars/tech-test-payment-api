using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Itens> Itens { get; set; }
        public DbSet<Compra> Compra { get; set; }
    }
}
