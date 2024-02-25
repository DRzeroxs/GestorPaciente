using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Context;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class CitaRepository : GenericRepository<Cita>, ICitaRepository
    {
        private readonly ApplicationContext _context;

        public CitaRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
