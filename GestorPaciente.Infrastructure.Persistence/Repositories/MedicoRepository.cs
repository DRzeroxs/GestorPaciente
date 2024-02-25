using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Context;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class MedicoRepository : GenericRepository<Medico>, IMedicoRepository
    {
        private readonly ApplicationContext _context;

        public MedicoRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
