using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Progreso1_1.Controllers
{
    public class PrendaController : Controller
    {
        // GET: PrendaController
        public ActionResult Index()
        {
            return View(Util.Utils.ListaPrenda);
        }

        // GET: PrendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        
        // GET: PrendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

       

        // GET: PrendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

      
        }
    }