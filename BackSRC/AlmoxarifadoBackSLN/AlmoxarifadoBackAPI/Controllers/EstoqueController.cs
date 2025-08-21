using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepositorio _db;
        public EstoqueController(IEstoqueRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/listaEstoque")]
        public IActionResult listaEstoque()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/Estoque")]
        public IActionResult listaEstoque(EstoqueDTO Estoque)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo== Estoque.Codigo));
        }

        [HttpPost("/criarEstoque")]
        public IActionResult criarEstoque(EstoqueCadastroDTO Estoque)
        {

            var novaEstoque = new Estoque()
            {               
                Produto = Estoque.Produto,
                Quantidade = Estoque.Quantidade
            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaEstoque);
            return Ok("Cadastro com Sucesso");
        }



    }
}
