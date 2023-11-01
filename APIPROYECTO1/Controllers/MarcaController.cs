using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : Controller
    {
        private readonly ApplicationDBContext _db;

        public MarcaController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<PrendaController>
        [HttpGet]
        public async Task<IActionResult> Get()//Se hace el nétodo asincrono 
        {
            List<Marca> marcas = await _db.Marcas.ToListAsync();
            return Ok(marcas);
        }

        // GET api/<PrendaController>/5
        [HttpGet("{IdMarca}")]
        public async Task<IActionResult> Get(int IdMarca)
        {
            Marca marca = await _db.Marcas.FirstOrDefaultAsync(x => x.IdMarca == IdMarca);
            if (marca == null)
            {
                return BadRequest();
            }
            return Ok(marca);
        }

        // POST api/<PrendaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Marca marca)
        {
                Marca marca2 = await _db.Marcas.FirstOrDefaultAsync(x => x.IdMarca == marca.IdMarca);
            if (marca2 == null && marca != null)
            {
                await _db.Marcas.AddAsync(marca);
                await _db.SaveChangesAsync();
                return Ok(marca);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<PrendaController>/5
        [HttpPut("{IdMarca}")]
        public async Task<IActionResult> Put(int IdMarca, [FromBody] Marca marca)
        {
            Marca marca2 = await _db.Marcas.FirstOrDefaultAsync(x => x.IdMarca == IdMarca);
            if (marca2 != null)
            {
                marca2.Nombre = marca.Nombre != null ? marca.Nombre : marca2.Nombre;
                marca2.Descripcion = marca.Descripcion != null ? marca.Descripcion : marca2.Descripcion;
                _db.Marcas.Update(marca2);
                await _db.SaveChangesAsync();
                return Ok(marca2);
            }
            return BadRequest("La marca no existe");
        }

        // DELETE api/<PrendaController>/5
        [HttpDelete("{IdMarca}")]
        public async Task<IActionResult> Delete(int IdMarca)
        {
            Marca marca = await _db.Marcas.FirstOrDefaultAsync(x => x.IdMarca == IdMarca);
            if (marca != null)
            {
                _db.Marcas.Remove(marca);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
