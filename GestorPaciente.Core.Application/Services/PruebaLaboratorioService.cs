using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.PruebasLaboratorio;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class PruebaLaboratorioService : GenericService<SavePruebaLaboratorioViewModel, PruebaLaboratorioViewModel, PruebaLaboratorio>, IPruebaLaboratorioService
    {
        private readonly IPruebaLaboratorioRepository _repository;
        private readonly IMapper _mapper;

        public PruebaLaboratorioService(IPruebaLaboratorioRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
    }
}
