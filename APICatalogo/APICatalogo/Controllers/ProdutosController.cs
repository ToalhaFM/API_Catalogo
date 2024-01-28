using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable <Produto>> get() {
            var produtos = _context.Produtos.ToList();
            if(produtos is null)
            {
                return NotFound("Produtos não encontrado!");
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name ="ObterProduto")]
        public ActionResult<Produto> get(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                if (produto is null)
                {
                    return NotFound();
                }
                return produto;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Problema a resolver :)");
            }
            
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            try
            {
                if (produto is null)
                {
                    return BadRequest();
                }
                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return new CreatedAtRouteResult("obterProduto",
                                        new { id = produto.ProdutoId }, produto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Produto {produto} dando problema");
            }
            
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest();
                }

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(produto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{id} não encontrado.");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

                if (produto is null)
                {
                    return NotFound();
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Problema no id {id}");
            }
        }
    }
}
