using GestorPaciente.Core.Application.ViewModels.Medicos;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IMedicoService : IGenericService<SaveMedicoViewModel, MedicoViewModel, Medico>
    {
    }
}
