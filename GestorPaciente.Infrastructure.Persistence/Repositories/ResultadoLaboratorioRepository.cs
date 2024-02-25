using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class ResultadoLaboratorioRepository : GenericRepository<ResultadoLaboratorio>, IResultadoLaboratorioRepository
    {
        private readonly ApplicationContext _context;

        public ResultadoLaboratorioRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ResultadoLaboratorio>> GetByCitaIdAsync(int citaId)
        {
            return await _context.ResultadoLaboratorios.Where(r => r.CitaId == citaId).ToListAsync();
        }

        public async Task<List<ResultadoLaboratorio>> GetAllResultViewModel()
        {
            var entityList = await _context.ResultadoLaboratorios
                .Include(r => r.PruebaLaboratorio)
                .Include(r => r.Cita)
                    .ThenInclude(c => c.Paciente) // Incluye la entidad Paciente relacionada con Cita
                .ToListAsync();

            return entityList;
        }


    }
}
