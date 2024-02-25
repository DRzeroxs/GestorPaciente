using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        private readonly ApplicationContext _context;

        public PacienteRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Paciente> GetAsyncById(int id)
        {
            return await _context.Set<Paciente>().FindAsync(id);
        }

    }
}
