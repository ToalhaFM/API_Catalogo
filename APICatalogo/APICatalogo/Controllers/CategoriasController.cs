using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produto")]
        public ActionResult<IEnumerable<Categoria>> GetCateriaProdutos()
        {
            //return _context.Categorias.Include(p => p.Produtos).ToList(); Nunca retorne todos os registro em uma consulta,
            //sempre usar um filtro e
            //Nunca retorne objetos relacionados sem aplicar um filtro
            try
            {
                return _context.Categorias.Include(p => p.Produtos).Where(c => c.CategoriaID <= 5).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro");
            }
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> get()
        {
            try
            {
                throw new DataMisalignedException();
            }catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
            
            //return _context.Categorias.AsNoTracking().ToList();
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> get(int id)
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaID == id);
                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada...");
                }
                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Produto id = {id} não encontrado.");
            }
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria) 
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest();
                }
                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria",
                    new { id = categoria.CategoriaID }, categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Id = {categoria} não encontrado.");
            }
            
        }

        [HttpPut("({id:int}")]
        public ActionResult put(int id,Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaID)
                {
                    return BadRequest();
                }
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Não será possivel atualizar a categoria {categoria}...");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult delete(int id)
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaID == id);

                if (categoria == null) { return NotFound(); }

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                return Ok(categoria);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao delete a categoria {id}");
            }
            
        }
    }
}
