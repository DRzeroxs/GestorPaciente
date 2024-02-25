using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Citas;
using GestorPaciente.Core.Application.ViewModels.Medicos;
using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPaciente.Core.Domain.Entities;
using System.Runtime.CompilerServices;

namespace GestorPaciente.Core.Application.Services
{
    public class CitaService : GenericService<SaveCitaViewModel, CitaViewModel, Cita>, ICitaService
    {
        private readonly ICitaRepository _repository;
        private readonly IResultadoLaboratorioRepository _resultadosRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public CitaService(ICitaRepository repository, IResultadoLaboratorioRepository resultadosRepository, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository,IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _resultadosRepository = resultadosRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public override async Task<List<CitaViewModel>> GetAllViewModel()
        {
            var citas = await _repository.GetAllAsync(); // Obtener todas las citas
            var citasViewModel = _mapper.Map<List<CitaViewModel>>(citas); // Mapear las citas a ViewModel

            // Iterar sobre cada cita para obtener y asignar los resultados de laboratorio
            foreach (var citaViewModel in citasViewModel)
            {
                var resultados = await _resultadosRepository.GetByCitaIdAsync(citaViewModel.Id);
                citaViewModel.Results = _mapper.Map<List<ResultadoLaboratorioViewModel>>(resultados);

                var medico = await _medicoRepository.GetByIdAsync(citaViewModel.MedicoId);
                citaViewModel.Medico =  _mapper.Map<MedicoViewModel>(medico);

                var paciente = await _pacienteRepository.GetByIdAsync(citaViewModel.PacienteId);
                citaViewModel.Paciente = _mapper.Map<PacienteViewModel>(paciente);
            }

            return citasViewModel;
        }
    }
}
