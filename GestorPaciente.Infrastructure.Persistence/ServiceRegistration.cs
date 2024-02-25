using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GestorPaciente.Infrastructure.Persistence.Context;
using GestorPaciente.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using GestorPaciente.Core.Application.Interfaces.Repositories;

namespace GestorPaciente.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("Default"),
                            m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)
                        )
                );
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICitaRepository, CitaRepository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IPruebaLaboratorioRepository, PruebaLaboratorioRepository>();
            services.AddTransient<IResultadoLaboratorioRepository, ResultadoLaboratorioRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            #endregion
        }
    }
}
