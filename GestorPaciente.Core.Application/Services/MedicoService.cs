using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Medicos;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class MedicoService : GenericService<SaveMedicoViewModel, MedicoViewModel, Medico>, IMedicoService
    {
        private readonly IMedicoRepository _repository;
        private readonly IMapper _mapper;

        public MedicoService(IMedicoRepository repository,  IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
