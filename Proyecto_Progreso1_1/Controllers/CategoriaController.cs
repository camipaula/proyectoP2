using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Progreso1_1.Models;
using Proyecto_Progreso1_1.NewFolder;

namespace Proyecto_Progreso1_1.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IServices _Services;

        // GET: ColorProductoController
        private readonly IServices _apiService;

        public CategoriaController(IServices apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Categoria> categorias = await _apiService.GetAllCategorias();
            return View("Index", categorias);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdCategoria)
        {
            Categoria tipo2 = await _apiService.GetCategoria(IdCategoria);
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
            // Obtener la lista de categorias
            List<Categoria> categorias = await _apiService.GetAllCategorias();

            // Almacena la lista de tipos de producto en ViewBag
            ViewBag.Categoria = new SelectList(categorias, "idCategoria", "nombre");

            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria productoapto)
        {
            Categoria tipo1 = await _apiService.CreateCategoria(productoapto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int idCategoria)
        {
            Categoria tipo = await _apiService.GetCategoria(idCategoria);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categoria categoriaCrea)
        {

            Console.WriteLine(categoriaCrea.nombre.ToString());
            Categoria tipo2 = await _apiService.GetCategoria(categoriaCrea.idCategoria);
            if (tipo2 != null)
            {
                Categoria tipo3 = await _apiService.UpdateCategoria(categoriaCrea.idCategoria,categoriaCrea);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idCategoria)
        {
            _apiService.DeleteCategoria(idCategoria);

            return RedirectToAction("Index");


        }

    }
}