using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Progreso1_1.Models;
using Proyecto_Progreso1_1.NewFolder;

namespace Proyecto_Progreso1_1.Controllers
{
    public class PrendaController : Controller
    {
        // GET: ColorProductoController
        private readonly IServices _apiService;

        public PrendaController(Services apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Prenda> tipos = await _apiService.GetAllPrendas();
            return View(tipos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdPrenda)
        {
            //Console.WriteLine(color..ToString());
            Prenda tipo2 = await _apiService.GetPrenda(IdPrenda);
            if (tipo2 != null)
            {
                return View(tipo2);
            }
            else
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public async Task<IActionResult> Create()
        {
            // Obtener la lista de tipos de producto
            List<Prenda> tipos = await _apiService.GetAllPrendas();

            // Almacena la lista de tipos de producto en ViewBag
            ViewBag.TipoProductos = new SelectList(tipos, "idTipoProducto", "nombre");

            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Create(Prenda productoapto)
        {
            Prenda tipo1 = await _apiService.CreatePrenda(productoapto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int idProducto)
        {
            Prenda tipo = await _apiService.GetPrenda(idProducto);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PrendaUsuario prendaUsuario)
        {
            
            Console.WriteLine(prendaUsuario.nombre.ToString());
            Prenda tipo2 = await _apiService.GetPrenda(prendaUsuario.idPrenda);
            if (tipo2 != null)
            {
                PrendaUsuario tipo3 = await _apiService.UpdatePrenda(prendaUsuario.idPrenda, prendaUsuario);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idProducto)
        {
            _apiService.DeletePrenda(idProducto);
            
                return RedirectToAction("Index");
           

        }
}