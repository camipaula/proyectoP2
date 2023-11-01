using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Progreso1_1.Models;
using Proyecto_Progreso1_1.NewFolder;

namespace Proyecto_Progreso1_1.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IServices _Services;

        // GET: ColorProductoController
        private readonly IServices _apiService;

        public MarcaController(IServices apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Marca> marcas = await _apiService.GetAllMarcas();
            return View("Index", marcas);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdMarca)
        {
            Marca tipo2 = await _apiService.GetMarca(IdMarca);
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
            List<Marca> marcas = await _apiService.GetAllMarcas();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Marca marcaa)
        {
            Marca tipo1 = await _apiService.CreateMarca(marcaa);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int idMarca)
        {
            Marca tipo = await _apiService.GetMarca(idMarca);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Marca marcac)
        {

            Console.WriteLine(marcac.nombre.ToString());
            Marca tipo2 = await _apiService.GetMarca(marcac.idMarca);
            if (tipo2 != null)
            {
                Marca tipo3 = await _apiService.UpdateMarca(marcac.idMarca, marcac);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idMarca)
        {
            _apiService.DeleteMarca(idMarca);

            return RedirectToAction("Index");


        }

    }
}