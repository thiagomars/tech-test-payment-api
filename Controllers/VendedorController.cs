using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Context.DTOs;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Buscar")]
        public IActionResult Get()
        {
            var vendedores = _context.Vendedor.ToList();

            return Ok(vendedores);
        }

        [HttpGet("Buscar{id}")]
        public IActionResult GetId(int id)
        {
            var vendedor = _context.Vendedor.FirstOrDefault(Vendedor => Vendedor.Id == id);
            if (vendedor == null)
                return NotFound();

            return Ok(vendedor);
        }

        [HttpPost]
        public IActionResult Create(CreateVendedorDTO dto)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.Telefone = dto.Telefone;
            vendedor.Cpf = dto.Cpf;
            vendedor.Nome = dto.Nome;
            vendedor.Email = dto.Email;

            _context.Add(vendedor);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var vendedor = _context.Vendedor.Find(id);
            if (vendedor == null)
                return NotFound();

            _context.Remove(vendedor);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, CreateVendedorDTO dto)
        {
            var vendedor = _context.Vendedor.Find(id);
            if (vendedor == null)
                return NotFound();

            vendedor.Telefone = dto.Telefone;
            vendedor.Cpf = dto.Cpf;
            vendedor.Nome = dto.Nome;
            vendedor.Email = dto.Email;
            
            _context.Vendedor.Update(vendedor);
            _context.SaveChanges();

            return Ok(vendedor);
        }
    }
}
