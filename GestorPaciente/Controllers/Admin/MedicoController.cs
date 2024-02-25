using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Medicos;
using GestorPaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.Controllers.Admin
{
    public class MedicoController : Controller
    {

        private readonly IMedicoService _medicoService;
        private readonly ValidateUserSession _userSession;

        public MedicoController(IMedicoService medicoService, ValidateUserSession userSession)
        {
            _medicoService = medicoService;
            _userSession = userSession;
        }


        public async Task<IActionResult> Index()
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(await _medicoService.GetAllViewModel());
        }

        [HttpGet]
        public IActionResult AgregarMedico()
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(new SaveMedicoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarMedico(SaveMedicoViewModel vm)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            SaveMedicoViewModel medicoVm = await _medicoService.Add(vm);

            if (medicoVm != null && medicoVm.Id != 0)
            {

                medicoVm.ImageUrl = FileManager.UploadFile(vm.File, medicoVm.Id);

                await _medicoService.Update(medicoVm, medicoVm.Id);
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditarMedico(int? id)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (id == null)
            {
                return NotFound();
            }

            SaveMedicoViewModel medico = await _medicoService.GetByIdSaveViewModel((int)id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarMedico(SaveMedicoViewModel vm)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            SaveMedicoViewModel medico = await _medicoService.GetByIdSaveViewModel(vm.Id);

            vm.ImageUrl = FileManager.UploadFile(vm.File, vm.Id, true, medico.ImageUrl);
            await _medicoService.Update(vm, vm.Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EliminarMedico(int id)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(await _medicoService.GetByIdSaveViewModel(id));
        }

        [HttpPost, ActionName("EliminarMedico")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (!_userSession.HasUserAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            await _medicoService.Delete(id);
            string basePath = $"/Images/People/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new(path);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo folder in directory.GetDirectories())
                {
                    folder.Delete(true);
                }

            }

            return RedirectToAction(nameof(Index));
        }
    }
}
