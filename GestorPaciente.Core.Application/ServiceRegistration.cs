using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GestorPaciente.Core.Application.Services;
using GestorPaciente.Core.Application.Interfaces.Services;
using System.Reflection;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient<ICitaService, CitaService>();
            services.AddTransient<IMedicoService, MedicoService>();
            services.AddTransient<IPacienteService, PacienteService>();
            services.AddTransient<IPruebaLaboratorioService, PruebaLaboratorioService>();
            services.AddTransient<IResultadoLaboratorioService, ResultadoLaboratorioService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            #endregion
        }
    }
}
