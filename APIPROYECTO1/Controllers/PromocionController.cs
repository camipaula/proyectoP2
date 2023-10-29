using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public PromocionController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<PromocionController>
        [HttpGet]
        public async Task<IActionResult> Get()//Se hace el nétodo asincrono 
        {
            List<Promocion> promociones = await _db.promociones.ToListAsync();
            return Ok(promociones);
        }

        // GET api/<PromocionController>/5
        [HttpGet("{IdPromocion}")]
        public async Task<IActionResult> Get(int IdPromocion)
        {
            Promocion promocion = await _db.promociones.FirstOrDefaultAsync(x => x.IdPromocion == IdPromocion);
            if (promocion == null)
            {
                return BadRequest();
            }
            return Ok(promocion);
        }

        // POST api/<PromocionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Promocion promocion)
        {
            Promocion promocion2 = await _db.promociones.FirstOrDefaultAsync(x => x.IdPromocion == promocion.IdPromocion);
            if (promocion2 == null && promocion != null)
            {
                await _db.promociones.AddAsync(promocion);
                await _db.SaveChangesAsync();
                return Ok(promocion);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<PrendaController>/5
        [HttpPut("{IdPromocion}")]
        public async Task<IActionResult> Put(int IdPromocion, [FromBody] Promocion promocion)
        {
            Promocion promocion2 = await _db.promociones.FirstOrDefaultAsync(x => x.IdPromocion == IdPromocion);
            if (promocion2 != null)
            {
                promocion2.Nombre = promocion.Nombre != null ? promocion.Nombre : promocion2.Nombre;
                promocion2.Descripcion = promocion.Descripcion != null ? promocion.Descripcion : promocion2.Descripcion;
                promocion2.Marca = promocion.Marca != null ? promocion.Marca : promocion2.Marca;
                promocion2.Cantidad = promocion.Cantidad != null ? promocion.Cantidad : promocion2.Cantidad;
                promocion2.Precio = promocion.Precio != null ? promocion.Precio : promocion2.Precio;
                _db.promociones.Update(promocion2);
                await _db.SaveChangesAsync();
                return Ok(promocion2);
            }
            return BadRequest("no existe");
        }

        // DELETE api/<PrendaController>/5
        [HttpDelete("{IdPromocion}")]
        public async Task<IActionResult> Delete(int IdPromocion)
        {
            Promocion promocion = await _db.promociones.FirstOrDefaultAsync(x => x.IdPromocion == IdPromocion);
            if (promocion != null)
            {
                _db.promociones.Remove(promocion);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}