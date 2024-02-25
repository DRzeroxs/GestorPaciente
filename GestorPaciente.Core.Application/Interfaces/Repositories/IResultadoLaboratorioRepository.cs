using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Interfaces.Repositories
{
    public interface IResultadoLaboratorioRepository : IGenericRepository<ResultadoLaboratorio>
    {
        public Task<List<ResultadoLaboratorio>> GetByCitaIdAsync(int citaId);

        public Task<List<ResultadoLaboratorio>> GetAllResultViewModel();
    }
}
