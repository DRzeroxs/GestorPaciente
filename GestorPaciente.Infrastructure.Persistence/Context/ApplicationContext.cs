using GestorPaciente.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Medico> Medicos {  get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PruebaLaboratorio> PruebasLaboratorios { get; set; }
        public DbSet<ResultadoLaboratorio> ResultadoLaboratorios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedby = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
