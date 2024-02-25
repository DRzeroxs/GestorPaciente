using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Citas;
using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.Controllers.Asistente
{
    public class CitaController : Controller
    {
        private readonly ICitaService _citaService;
        private readonly ValidateUserSession _userSession;
        private readonly IResultadoLaboratorioService _resultadoLaboratorioService;
        private readonly IPruebaLaboratorioService _pruebaLaboratorioService;
        private readonly IPacienteService _pacienteService;
        private readonly IMedicoService _medicoService;

        public CitaController(ICitaService citaService, ValidateUserSession userSession, IResultadoLaboratorioService resultadoLaboratorioService, IPacienteService pacienteService, IMedicoService medicoService, IPruebaLaboratorioService pruebaLaboratorioService)
        {
            _citaService = citaService;
            _userSession = userSession;
            _resultadoLaboratorioService = resultadoLaboratorioService;
            _pruebaLaboratorioService = pruebaLaboratorioService;
            _pacienteService = pacienteService;
            _medicoService = medicoService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(await _citaService.GetAllViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> AgregarCita()
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            SaveCitaViewModel vm = new();
            vm.Pacientes = await _pacienteService.GetAllViewModel();
            vm.Medicos = await _medicoService.GetAllViewModel();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarCita(SaveCitaViewModel vm)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _citaService.Add(vm);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> SeleccionarPruebas(int id)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            AsignarPruebaViewModel vm = new();

            vm.Pruebas = await _pruebaLaboratorioService.GetAllViewModel();
            vm.CitaId = id;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeleccionarPruebas(AsignarPruebaViewModel vm)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            SaveCitaViewModel cita = await _citaService.GetByIdSaveViewModel(vm.CitaId);

            if (cita != null)
            {
                cita.PendingQuery = false;
                cita.PendingResult = true;

                await _citaService.Update(cita, cita.Id);
            }

            await _resultadoLaboratorioService.AddAllSelect(vm, vm.CitaId);

           

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EliminarCita(int? id)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if(id == null)
            {
                return NotFound();
            }
            
            SaveCitaViewModel cita = await _citaService.GetByIdSaveViewModel((int)id);

            if (cita == null)
            {
                return NotFound();
            }


            cita.Pacientes = await _pacienteService.GetAllViewModel();
            cita.Medicos = await _medicoService.GetAllViewModel();

            return View(cita);
        }

        [HttpPost, ActionName("EliminarCita")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            SaveCitaViewModel cita = await _citaService.GetByIdSaveViewModel((int)id);

            if (cita == null)
            {
                return NotFound();
            }

            await _citaService.Delete(cita.Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CompletarCita(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SaveCitaViewModel cita = await _citaService.GetByIdSaveViewModel((int)id);

            if (cita == null)
            {
                return NotFound();
            }

            cita.Complete = true;
            cita.PendingQuery = false;
            cita.PendingResult = false;

            await _citaService.Update(cita, cita.Id);

            return RedirectToAction(nameof(Index));
        }
        
    }
}
