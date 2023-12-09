using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Progreso1_1.Models;
using Proyecto_Progreso1_1.NewFolder;

namespace Proyecto_Progreso1_1.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IServices _Services;

        // GET: ColorProductoController
        private readonly IServices _apiService;

        public UsuarioController(IServices apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> login(string usuario, string contrasena)
        {
            Usuario usuario1 = await _apiService.GetUsuario(usuario, contrasena);
            if (usuario1 == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }



        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
            List<Usuario> usuarios = await _apiService.GetAdmin();
            return View("Index", usuarios);
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> Details(int IdUsuario)
        {
            Usuario tipo2 = await _apiService.GetUsuario(IdUsuario);
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



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuariooo)
        {
            Usuario usuario = await _apiService.CreateUsuario(usuariooo);
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Edit(int idUsuario)
        {
            Usuario tipo = await _apiService.GetUsuario(idUsuario);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuarioe)
        {

            Usuario tipo2 = await _apiService.GetUsuario(usuarioe.idUsuario);
            if (tipo2 != null)
            {
                Usuario tipo3 = await _apiService.UpdateUsuario(usuarioe.idUsuario, usuarioe);

                return RedirectToAction("Index");
            }
            return View();
        }






        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idUsuario)
        {
            _apiService.DeleteUsuario(idUsuario);

            return RedirectToAction("Index");


        }



        public async Task<IActionResult> Search()
        {
            try
            {
                if (int.TryParse(Request.Query["IdUsuario"], out int idUsuario))
                {
                    Usuario usuario2 = await _apiService.GetUsuario(idUsuario);
                    if (usuario2 != null )
                    {
                        if (usuario2.tipo != false) {
                            return View("Details", usuario2);
                        }
                         return View("Error, no se encuentra el usuario");
                    }
                    return View("Error, no se encuentra el usuario");
                }
                return View("Error no se enconrto el usuario");
            }
            catch (Exception ex)
            {
                return View("Error no se enconrto el usuario");
            }

        }


    }
}