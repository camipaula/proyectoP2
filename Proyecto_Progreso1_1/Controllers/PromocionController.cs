using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Progreso1_1.Models;
using Proyecto_Progreso1_1.NewFolder;

namespace Proyecto_Progreso1_1.Controllers
{
    public class PromocionController : Controller
    {
        private readonly IServices _Services;

        public PromocionController(IServices Services)
        {
            _Services = Services;
        }

        public async Task<IActionResult> Index()
        {
            var promociones = await _Services.GetAllPromociones();
            return View(promociones);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Promocion promocion)
        {
            await _Services.CreatePromocion(promocion);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int IdPromocion)
        {
            var promocion = await _Services.GetPromocion(IdPromocion);
            if (promocion != null) return View(promocion);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int IdPromocion)
        {
            var promocion = await _Services.GetPromocion(IdPromocion);
            if (promocion != null) return View(promocion);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int IdPromocion, Promocion promocion)
        {
            await _Services.UpdatePromocion(IdPromocion, promocion);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int IdPromocion)
        {
            _Services.DeletePromocion(IdPromocion);
            return RedirectToAction("Index");
        }


    }
}