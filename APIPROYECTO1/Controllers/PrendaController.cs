using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrendaController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public PrendaController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<PrendaController>
        [HttpGet]
        public async Task<IActionResult> Get()//Se hace el nétodo asincrono 
        {
            List<Prenda> products = await _db.Prendas.ToListAsync();
            return Ok(products);
        }
       
        // GET api/<PrendaController>/5
        [HttpGet("{IdPrenda}")]
        public async Task<IActionResult> Get(int IdPrenda)
        {
            Prenda prenda = await _db.Prendas.FirstOrDefaultAsync(x => x.IdPrenda == IdPrenda);
            if (prenda == null)
            {
                return BadRequest();
            }
            return Ok(prenda);
        }

        // POST api/<PrendaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Prenda prenda)
        {
            Prenda prenda2 = await _db.Prendas.FirstOrDefaultAsync(x => x.IdPrenda == prenda.IdPrenda);
            if (prenda2 == null && prenda != null)
            {
                await _db.Prendas.AddAsync(prenda);
                await _db.SaveChangesAsync();
                return Ok(prenda);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<PrendaController>/5
        [HttpPut("{IdPrenda}")]
        public async Task<IActionResult> Put(int IdPrenda, [FromBody] Prenda prenda)
        {
            Prenda prenda2 = await _db.Prendas.FirstOrDefaultAsync(x => x.IdPrenda == IdPrenda);
            if (prenda2 != null)
            {
                prenda2.Nombre = prenda.Nombre != null ? prenda.Nombre : prenda2.Nombre;
                prenda2.Descripcion = prenda.Descripcion != null ? prenda.Descripcion : prenda2.Descripcion;
                prenda2.Marca = prenda.Marca != null ? prenda.Marca : prenda2.Marca;
                prenda2.Categoria = prenda.Categoria != null ? prenda.Categoria : prenda2.Categoria;
                prenda2.Cantidad = prenda.Cantidad != null ? prenda.Cantidad : prenda2.Cantidad;
                prenda2.Precio = prenda.Precio != null ? prenda.Precio : prenda2.Precio;
                _db.Prendas.Update(prenda2);
                await _db.SaveChangesAsync();
                return Ok(prenda2);
            }
            return BadRequest("El prenda no existe");
        }

        // DELETE api/<PrendaController>/5
        [HttpDelete("{IdPrenda}")]
        public async Task<IActionResult> Delete(int IdPrenda)
        {
            Prenda prenda = await _db.Prendas.FirstOrDefaultAsync(x => x.IdPrenda == IdPrenda);
            if (prenda != null)
            {
                _db.Prendas.Remove(prenda);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
