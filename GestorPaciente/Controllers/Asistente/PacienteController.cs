using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.Services;
using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GestorPaciente.Controllers.Asistente
{
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;
        private readonly ValidateUserSession _userSession;

        public PacienteController(IPacienteService pacienteService, ValidateUserSession userSession)
        {
            _pacienteService = pacienteService;
            _userSession = userSession;
        }


        public async Task<IActionResult> Index()
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(await _pacienteService.GetAllViewModel());
        }

        [HttpGet]
        public IActionResult AgregarPaciente()
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(new SavePacienteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarPaciente(SavePacienteViewModel vm)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            SavePacienteViewModel paciente = await _pacienteService.Add(vm);

            if (paciente != null && paciente.Id != 0)
            {
                paciente.ImageUrl = FileManager.UploadFile(vm.File, paciente.Id);
                await _pacienteService.Update(paciente, paciente.Id);
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditarPaciente(int? id)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (id == null)
            {
                return NotFound();

            }

            SavePacienteViewModel paciente = await _pacienteService.GetByIdSaveViewModel((int)id);

            if (paciente == null)
            {
                return NotFound();
            }


            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPaciente(SavePacienteViewModel vm)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            SavePacienteViewModel paciente = await _pacienteService.GetByIdSaveViewModel(vm.Id);

            vm.ImageUrl = FileManager.UploadFile(vm.File, vm.Id, true, paciente.ImageUrl);

            await _pacienteService.Update(vm, vm.Id);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> EliminarPaciente(int id)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(await _pacienteService.GetByIdSaveViewModel(id));
        }

        [HttpPost, ActionName("EliminarPaciente")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            await _pacienteService.Delete(id);
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
