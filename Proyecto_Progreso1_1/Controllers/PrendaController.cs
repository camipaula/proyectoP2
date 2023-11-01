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
            
        public PrendaController(IServices apiService)
        {
            _apiService = apiService;
        }


        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
           List<Prenda> prendas = await _apiService.GetAllPrendas();
            return View("Index", prendas);
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
            List<Prenda> prendas = await _apiService.GetAllPrendas();
            List<Categoria> categorias = await _apiService.GetAllCategorias();
            List<Marca> marcas = await _apiService.GetAllMarcas();

            // Almacena la lista de tipos de producto en ViewBag
            ViewBag.Categoria = new SelectList(categorias, "idCategoria", "nombre");
            ViewBag.Marca = new SelectList(marcas, "idMarca", "nombre");

            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Create(PrendaUsuario productoapto)
        {
            Prenda tipo1 = await _apiService.CreatePrenda(productoapto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int idPrenda)
        {
            Prenda tipo = await _apiService.GetPrenda(idPrenda);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Prenda prendaUsuario)
        {

            Console.WriteLine(prendaUsuario.nombre.ToString());
            Prenda tipo2 = await _apiService.GetPrenda(prendaUsuario.idPrenda);
            if (tipo2 != null)
            {
                Prenda tipo3 = await _apiService.UpdatePrenda(prendaUsuario.idPrenda, prendaUsuario);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idPrenda)
        {
            _apiService.DeletePrenda(idPrenda);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Search()
        {
            try {
                if (int.TryParse(Request.Query["IdPrenda"], out int idPrenda))
                {
                    Prenda prenda2 = await _apiService.GetPrenda(idPrenda);
                    if (prenda2 != null)
                    {
                        return View("Details", prenda2);
                    }
                    return View("Error");
                }
                return View("Error");
            } catch (Exception ex)
            {
                return View("Error");
            }

            }




    }
}