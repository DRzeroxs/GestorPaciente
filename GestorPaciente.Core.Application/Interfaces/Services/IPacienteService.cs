using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IPacienteService : IGenericService<SavePacienteViewModel, PacienteViewModel, Paciente>
    {
        public Task<PacienteViewModel> GetById(int id);
    }
}
