namespace tech_test_payment_api.Context.DTOs
{
    public class CreateVendedorDTO
    {
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
    }
}
