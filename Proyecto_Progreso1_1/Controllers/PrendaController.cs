using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Progreso1_1.Models;
using Proyecto_Progreso1_1.NewFolder;

namespace Proyecto_Progreso1_1.Controllers
{
    public class PrendaController : Controller
    {
        private readonly IServices _Services;

        public PrendaController(IServices Services)
        {
            _Services = Services;
        }

        public async Task<IActionResult> Index()
        {
            var prendas = await _Services.GetAllPrendas();
            return View(prendas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Prenda prenda)
        {
            await _Services.CreatePrenda(prenda);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int IdPrenda)
        {
            var prenda = await _Services.GetPrenda(IdPrenda);
            if (prenda != null) return View(prenda);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int IdPrenda)
        {
            var prenda = await _Services.GetPrenda(IdPrenda);
            if (prenda != null) return View(prenda);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int IdPrenda, Prenda prenda)
        {
            await _Services.UpdatePrenda(IdPrenda, prenda);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int IdPrenda)
        {
            _Services.DeletePrenda(IdPrenda);
            return RedirectToAction("Index");
        }


        public ActionResult Accesorio()
        {
            return View();
        }

        public ActionResult Promociones()
        {
            return View();
        }

    }
}