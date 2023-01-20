using tech_test_payment_api.Models;

namespace tech_test_payment_api.Context.DTOs
{
    public class CreateVendaDTO
    {
        public int Vendedor { get; set; }
        public IList<Itens> Itens { get; set; } 
    }
}
