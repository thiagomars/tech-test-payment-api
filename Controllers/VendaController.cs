using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using tech_test_payment_api.Context;
using tech_test_payment_api.Context.DTOs;
using tech_test_payment_api.Models;
using techtestpaymentapi.Migrations;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("BuscaVendaDadosCompleto")]
        public IActionResult GetComlpeto()
        {
            var venda = _context.Compra.Include(venda => venda.Venda).ThenInclude(vendedor => vendedor.Vendedor).Include(item => item.Itens).ToList();
            return Ok(venda);
        }

        [HttpGet ("BuscarVenda")]
        public IActionResult GetSimples()
        {
            var venda = _context.Vendas.Include(i => i.Vendedor).ToList();
            return Ok(venda);
        }

        [HttpGet("BuscarCompra/{idVenda}")]
        public IActionResult GetCompra(int idVenda)
        {
            var venda = _context.Compra.Include(i => i.Itens).ToList().Where(i => i.VendaId == idVenda);
            return Ok(venda);
        }

        [HttpGet("Buscar{id}")]
        public IActionResult Get(int id)
        {
            var venda = _context.Vendas.Find(id);
            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPost]
        public IActionResult Put(int id, IList<int> idProdutos)
        {
            var vendedor = _context.Vendedor.FirstOrDefault(aux => aux.Id == id);
            if (vendedor == null)
                return NotFound("Vendedor nao encontrado");

            if (idProdutos.Count < 1)
                return NotFound("Nenhum produto selecionado");

            Venda novaVenda = new Venda();

            novaVenda.Vendedor = vendedor;
            novaVenda.Data = DateTime.Now.ToString();
            novaVenda.Status = EnumStatus.AguardandoPagamento;

            _context.Vendas.Add(novaVenda);
            _context.SaveChanges();
            
            foreach(var item in idProdutos)
            {
                var produto = _context.Itens.Find(item);
                
                if (produto == null)
                    return NotFound("Id do produto nao encontrado");

                var compraAtual = new Compra();
                compraAtual.ItensId = produto.Id;
                compraAtual.VendaId = novaVenda.Id;

                _context.Compra.Add(compraAtual);
            }

            _context.SaveChanges();

            return Ok("Acho q foi");
        }

        [HttpPatch ("AlterarStatus")]
        public IActionResult Put(EnumStatus status, int id)
        {
            var venda = _context.Vendas.Find(id);
            if (venda == null)
                return NotFound("Venda nao encontrada");

            string novoStatus = status.ToString();

            switch (venda.Status.ToString())
            {
                case "AguardandoPagamento":
                    if (!(novoStatus == "PagamentoAprovado" || novoStatus == "Cancelada"))
                    { return BadRequest("1No status de AguardandoPagamento é possível apenas retornar ou 'PagamentoAprovado' ou 'Cancelada'"); }
                    break;

                case "PagamentoAprovado":
                    if (!(novoStatus == "EnviadoParaTransportadora" || novoStatus == "Cancelada"))
                    { return BadRequest("2No status de PagamentoAprovado é possível apenas retornar ou 'EnviadoParaTransportadora' ou 'Cancelada'"); }
                    break;

                case "EnviadoParaTransportadora":
                    if (!(novoStatus == "Entregue" || novoStatus == "Cancelada"))
                    { return BadRequest("3No status de EnviadoParaTransportadora é possível apenas retornar ou 'Entregue' ou 'Cancelada'"); }
                    break;
            }

            venda.Status = status;

            _context.Vendas.Update(venda);
            _context.SaveChanges();

            return Ok();

        }

    }
}
