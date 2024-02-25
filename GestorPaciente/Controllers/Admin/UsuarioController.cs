using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Usuario;
using GestorPaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.Controllers.Admin
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ValidateUserSession _userSession;

        public UsuarioController(IUsuarioService usuarioService, ValidateUserSession userSession)
        {
            _usuarioService = usuarioService;
            _userSession = userSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            
            return View(await _usuarioService.GetAllViewModel());
        }

       
        public IActionResult AgregarUsuario()
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(new SaveUsuarioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarUsuario(SaveUsuarioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if(await _usuarioService.UserNameExists(vm.UserName))
            {
                ModelState.AddModelError("UserName", "El nombre de usuario ya existe");
                return View(vm);
            }

            await _usuarioService.Add(vm);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditarUsuario(int? id)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (id == null)
            {
                return NotFound();
            }

            SaveUsuarioViewModel usuario = await _usuarioService.GetByIdSaveViewModel((int)id);

            if(usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarUsuario(SaveUsuarioViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.Update(vm, vm.Id);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EliminarUsuario(int? id)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (id == null)
            {
                return NotFound();
            }

            SaveUsuarioViewModel usuario = await _usuarioService.GetByIdSaveViewModel((int)id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("EliminarUsuario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SaveUsuarioViewModel usuario = await _usuarioService.GetByIdSaveViewModel((int)id);

            if (usuario == null)
            {
                return View();
            }

            //borrado
            await _usuarioService.Delete(usuario.Id);

            return RedirectToAction(nameof(Index));
        }


    }
}
