using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Interfaces.Repositories
{
    public interface IPacienteRepository : IGenericRepository<Paciente>
    {
        public Task<Paciente> GetAsyncById(int id);
    }
}
