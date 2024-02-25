using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class PacienteService : GenericService<SavePacienteViewModel, PacienteViewModel, Paciente>, IPacienteService
    {
        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PacienteViewModel> GetById(int id)
        {
            var paciente = await _repository.GetByIdAsync(id);

            return _mapper.Map<PacienteViewModel>(paciente);
        }



    }
}
