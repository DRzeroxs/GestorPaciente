using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Citas;
using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.Controllers.Asistente
{
    public class ResultadoLaboratorioController : Controller
    {
        private readonly IResultadoLaboratorioService _resultadoLaboratorioService;
        private readonly ICitaService _citaService;
        private readonly IPacienteService _pacienteService;
        private readonly IPruebaLaboratorioService _pruebaLaboratorioService;
        private readonly ValidateUserSession _userSession;

        public ResultadoLaboratorioController (IResultadoLaboratorioService resultadoLaboratorioService, ValidateUserSession userSession, ICitaService citaService, IPacienteService pacienteService, IPruebaLaboratorioService pruebaLaboratorioService)
        {
            _resultadoLaboratorioService = resultadoLaboratorioService;
            _userSession = userSession;
            _citaService = citaService;
            _pacienteService = pacienteService;
            _pruebaLaboratorioService = pruebaLaboratorioService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            var resultados = await _resultadoLaboratorioService.GetAllViewModel();

            resultados = resultados.Where(item => item.Pending).ToList();

            foreach (ResultadoLaboratorioViewModel item in resultados)
            {
                item.Paciente = item.Cita.Paciente;  /*_pacienteService.GetById(item.Cita.PacienteId);*/
            }

            return View(resultados);
        }

        public async Task<IActionResult> VerResultadoCita(int? id)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (id == null)
            {
                return NotFound();
            }

            var resultados = await _resultadoLaboratorioService.GetAllViewModel();

            resultados = resultados.Where(item => item.Cita.Id == id).ToList();

            foreach (ResultadoLaboratorioViewModel item in resultados)
            {
                item.Paciente = item.Cita.Paciente;
            }

            return View(resultados);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FiltrarCedula(string cedula)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if(cedula == null)
            {
                return NotFound();
            }

            var resultados = await _resultadoLaboratorioService.GetAllViewModel();

            foreach (ResultadoLaboratorioViewModel item in resultados)
            {
                item.Paciente = item.Cita.Paciente;  
            }

            resultados = resultados.Where(item => item.Paciente.Cedula == cedula).ToList();

            return View("Index", resultados);
        }

        [HttpGet]
        public async Task<IActionResult> CompletarResultadoLaboratorio(int? id)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (id == null)
            {
                return NotFound();
            }

            SaveResultadoLaboratorioViewModel resultado = await _resultadoLaboratorioService.GetByIdSaveViewModel((int)id);

            if(resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletarResultadoLaboratorio(SaveResultadoLaboratorioViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            await _resultadoLaboratorioService.Update(vm, vm.Id);

            return RedirectToAction(nameof(Index));
        }

        
        [HttpGet]
        public async Task<IActionResult> VerResultadoLaboratorio(int? id)
        {
            if (!_userSession.HasUserAsistent())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if(id  == null)
            {
                return NotFound();
            }

            SaveResultadoLaboratorioViewModel resultado = await _resultadoLaboratorioService.GetByIdSaveViewModel((int)id);

            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

    }
}
