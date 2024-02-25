using GestorPaciente.Core.Application.ViewModels.Usuario;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> LoginAsync(LoginViewModel loginVM);

        public Task<bool> UserNameExistsAsync(string userName);
    }
}
