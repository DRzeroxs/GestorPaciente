using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class ResultadoLaboratorioService : GenericService<SaveResultadoLaboratorioViewModel, ResultadoLaboratorioViewModel, ResultadoLaboratorio>, IResultadoLaboratorioService
    {
        private readonly IResultadoLaboratorioRepository _repository;
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public ResultadoLaboratorioService(IResultadoLaboratorioRepository repository, IMapper mapper, ICitaRepository citaRepository) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _citaRepository = citaRepository;
        }

        public override async Task<List<ResultadoLaboratorioViewModel>> GetAllViewModel()
        {
            var entityList = await _repository.GetAllResultViewModel();

            return  _mapper.Map<List<ResultadoLaboratorioViewModel>>(entityList);
        }

        public async Task<List<ResultadoLaboratorio>> GetAllByCitaId(int id)
        {
            var entityList = await _repository.GetByCitaIdAsync(id);

            return _mapper.Map<List<ResultadoLaboratorio>>(entityList);
        }

        public async Task<AsignarPruebaViewModel> AddAllSelect(AsignarPruebaViewModel vm, int citaId)
        {
            foreach (int prueba in vm.PruebasSelesccionadas)
            {

                SaveResultadoLaboratorioViewModel resultadoVm = new SaveResultadoLaboratorioViewModel
                {
                    Result = "---",
                    Pending = true,
                    PruebaLaboratorioId = prueba,
                    CitaId = citaId
                };


                await Add(resultadoVm);
            }


            return vm;
        }

    }
}
