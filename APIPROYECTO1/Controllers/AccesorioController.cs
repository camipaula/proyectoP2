using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesorioController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public AccesorioController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<PrendaController>
        [HttpGet]
        public async Task<IActionResult> Get()//Se hace el nétodo asincrono 
        {
            List<Accesorios> accesorios = await _db.Accesorios.ToListAsync();
            return Ok(accesorios);
        }

        // GET api/<PrendaController>/5
        [HttpGet("{IdAccesorio}")]
        public async Task<IActionResult> Get(int IdAccesorio)
        {
            Accesorios accesorio = await _db.Accesorios.FirstOrDefaultAsync(x => x.IdAccesorio == IdAccesorio);
            if (accesorio == null)
            {
                return BadRequest();
            }
            return Ok(accesorio);
        }

        // POST api/<PrendaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Accesorios accesorio)
        {
            Accesorios accesorio2 = await _db.Accesorios.FirstOrDefaultAsync(x => x.IdAccesorio == accesorio.IdAccesorio);
            if (accesorio2 == null && accesorio != null)
            {
                await _db.Accesorios.AddAsync(accesorio);
                await _db.SaveChangesAsync();
                return Ok(accesorio);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<PrendaController>/5
        [HttpPut("{IdAccesorio}")]
        public async Task<IActionResult> Put(int IdAccesorio, [FromBody] Accesorios accesorio)
        {
            Accesorios accesorio2 = await _db.Accesorios.FirstOrDefaultAsync(x => x.IdAccesorio == IdAccesorio);
            if (accesorio2 != null)
            {
                accesorio2.Nombre = accesorio.Nombre != null ? accesorio.Nombre : accesorio2.Nombre;
                accesorio2.Descripcion = accesorio.Descripcion != null ? accesorio.Descripcion : accesorio2.Descripcion;
                accesorio2.Marca = accesorio.Marca != null ? accesorio.Marca : accesorio2.Marca;
                accesorio2.Cantidad = accesorio.Cantidad != null ? accesorio.Cantidad : accesorio2.Cantidad;
                accesorio2.Precio = accesorio.Precio != null ? accesorio.Precio : accesorio2.Precio;
                _db.Accesorios.Update(accesorio2);
                await _db.SaveChangesAsync();
                return Ok(accesorio2);
            }
            return BadRequest("El prenda no existe");
        }

        // DELETE api/<PrendaController>/5
        [HttpDelete("{IdAccesorio}")]
        public async Task<IActionResult> Delete(int IdAccesorio)
        {
            Accesorios accesorio = await _db.Accesorios.FirstOrDefaultAsync(x => x.IdAccesorio == IdAccesorio);
            if (accesorio != null)
            {
                _db.Accesorios.Remove(accesorio);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}