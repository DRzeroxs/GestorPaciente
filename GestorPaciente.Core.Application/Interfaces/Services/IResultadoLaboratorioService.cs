using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPaciente.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IResultadoLaboratorioService : IGenericService<SaveResultadoLaboratorioViewModel, ResultadoLaboratorioViewModel, ResultadoLaboratorio>
    {

        public Task<AsignarPruebaViewModel> AddAllSelect(AsignarPruebaViewModel vm, int citaId);

    }
}
