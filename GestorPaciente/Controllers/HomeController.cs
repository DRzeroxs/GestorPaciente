using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Usuario;
using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Middlewares;
using GestorPaciente.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestorPaciente.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        private readonly ValidateUserSession _validateUserSession;

        public HomeController (IUsuarioService usuarioService, ValidateUserSession validateUserSession)
        {
            _usuarioService = usuarioService;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction(nameof(Administrador));
            }
            if (_validateUserSession.HasUserAsistent())
            {

                return RedirectToAction(nameof(Asistente));
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index (LoginViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            if (_validateUserSession.HasUserAdmin())
            {
                return RedirectToRoute(nameof(Administrador));
            }
            if (_validateUserSession.HasUserAsistent())
            {

                return RedirectToAction(nameof(Asistente));
            }

            UsuarioViewModel userVm = await _usuarioService.Login(vm);

            if (userVm != null)
            {
                HttpContext.Session.Set<UsuarioViewModel>("user", userVm);

                if (_validateUserSession.HasUserAdmin())
                {
                    return RedirectToAction(nameof(Administrador));
                }
                if (_validateUserSession.HasUserAsistent())
                {

                    return RedirectToRoute(new { controller = "Home", action = "Asistente" });
                }
            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso Incorrecto");
            }

            return View(vm);    

        }

        public IActionResult Administrador()
        {
            if (!_validateUserSession.HasUserAdmin())
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Asistente()
        {
            if (!_validateUserSession.HasUserAsistent())
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
