using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.PruebasLaboratorio;
using GestorPaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.Controllers.Admin
{
    public class PruebaLaboratorioController : Controller
    {

        private readonly IPruebaLaboratorioService _PruebaLaboratorioService;
        private readonly ValidateUserSession _userSession;

        public PruebaLaboratorioController(IPruebaLaboratorioService pruebaLaboratorioService, ValidateUserSession userSession)
        {
            _PruebaLaboratorioService = pruebaLaboratorioService;
            _userSession = userSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(await _PruebaLaboratorioService.GetAllViewModel());
        }

        public IActionResult AgregarPruebaLaboratorio()
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(new SavePruebaLaboratorioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarPruebaLaboratorio(SavePruebaLaboratorioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _PruebaLaboratorioService.Add(vm);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditarPruebaLaboratorio(int? id)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if(id == null)
            {
                return NotFound();
            }

            SavePruebaLaboratorioViewModel prueba = await  _PruebaLaboratorioService.GetByIdSaveViewModel((int)id);

            if (prueba == null)
            {
                return NotFound();
            }
 
            return View(prueba);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPruebaLaboratorio(SavePruebaLaboratorioViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _PruebaLaboratorioService.Update(vm, vm.Id);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EliminarPruebaLaboratorio(int? id)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if(id == null)
            {
                return NotFound();
            }

            SavePruebaLaboratorioViewModel prueba = await _PruebaLaboratorioService.GetByIdSaveViewModel((int)id);

            if (prueba == null)
            {
                return NotFound();
            }

            return View(prueba);
        }

        [HttpPost, ActionName("EliminarPruebaLaboratorio")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SavePruebaLaboratorioViewModel prueba = await _PruebaLaboratorioService.GetByIdSaveViewModel((int)id);

            if (prueba == null)
            {
                return View();
            }

            //borrado
            await _PruebaLaboratorioService.Delete(prueba.Id);

            return RedirectToAction(nameof(Index));
        }


    }
}
