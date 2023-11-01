using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Progreso1_1.Models;
using Proyecto_Progreso1_1.NewFolder;

namespace Proyecto_Progreso1_1.Controllers
{
    public class AccesorioController : Controller
    {
        private readonly IServices _Services;

        public AccesorioController(IServices Services)
        {
            _Services = Services;
        }

        public async Task<IActionResult> Index()
        {
            var accesorios = await _Services.GetAllAccesorios();
            return View(accesorios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Accesorio accesorio)
        {
            await _Services.CreateAccesorio(accesorio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int IdAccesorio)
        {
            var accesorio = await _Services.GetAccesorio(IdAccesorio);
            if (accesorio != null) return View(accesorio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int IdAccesorio)
        {
            var accesorio = await _Services.GetAccesorio(IdAccesorio);
            if (accesorio != null) return View(accesorio);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int IdAccesorio, Accesorio accesorio)
        {
            await _Services.UpdateAccesorio(IdAccesorio, accesorio);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int IdAccesorio)
        {
            _Services.DeleteAccesorio(IdAccesorio);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Search()
        {
            try
            {
                if (int.TryParse(Request.Query["IdAccesorio"], out int idAccesorio))
                {
                    Accesorio accesorio2 = await _Services.GetAccesorio(idAccesorio);
                    if (accesorio2 != null)
                    {
                        return View("Details", accesorio2);
                    }
                }
                return View("Error");
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }


    }
}