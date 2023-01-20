using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItensController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Buscar")]
        public IActionResult Get()
        {
            var itens = _context.Itens.ToList();
            return Ok(itens);
        }

        [HttpGet("Buscar{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.Itens.Find(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Adicionar(string nome, decimal preco)
        {
            Itens item = new Itens();
            item.Nome = nome;
            item.Preco = preco;

            _context.Itens.Add(item);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var item = _context.Itens.Find(id);
            if(item == null)
                return NotFound();

            _context.Itens.Remove(item);
            _context.SaveChanges();

            return Ok();
        }
    }
}
