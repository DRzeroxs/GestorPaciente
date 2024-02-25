using GestorPaciente.Core.Application.ViewModels.PruebasLaboratorio;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IPruebaLaboratorioService : IGenericService<SavePruebaLaboratorioViewModel, PruebaLaboratorioViewModel, PruebaLaboratorio>
    {
    }
}
