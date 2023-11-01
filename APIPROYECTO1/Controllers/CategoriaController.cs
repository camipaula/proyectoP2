using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public CategoriaController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<PrendaController>
        [HttpGet]
        public async Task<IActionResult> Get()//Se hace el nétodo asincrono 
        {
            List<Categoria> categorias = await _db.Categorias.ToListAsync();
            return Ok(categorias);
        }

        // GET api/<PrendaController>/5
        [HttpGet("{IdCategoria}")]
        public async Task<IActionResult> Get(int IdCategoria)
        {
            Categoria categoria = await _db.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == IdCategoria);
            if (categoria == null)
            {
                return BadRequest();
            }
            return Ok(categoria);
        }

        // POST api/<PrendaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            Categoria categoria2 = await _db.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == categoria.IdCategoria);
            if (categoria2 == null && categoria != null)
            {
                await _db.Categorias.AddAsync(categoria);
                await _db.SaveChangesAsync();
                return Ok(categoria);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<PrendaController>/5
        [HttpPut("{IdCategoria}")]
        public async Task<IActionResult> Put(int IdCategoria, [FromBody] Categoria categoria)
        {
            Categoria categoria2 = await _db.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == IdCategoria);
            if (categoria2 != null)
            {
                categoria2.Nombre = categoria.Nombre != null ? categoria.Nombre : categoria2.Nombre;
                categoria2.Descripcion = categoria.Descripcion != null ? categoria.Descripcion : categoria2.Descripcion;
                _db.Categorias.Update(categoria2);
                await _db.SaveChangesAsync();
                return Ok(categoria2);
            }
            return BadRequest("La categoria no existe");
        }

        // DELETE api/<PrendaController>/5
        [HttpDelete("{IdCategoria}")]
        public async Task<IActionResult> Delete(int IdCategoria)
        {
            Categoria categoria = await _db.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == IdCategoria);
            if (categoria != null)
            {
                _db.Categorias.Remove(categoria);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
