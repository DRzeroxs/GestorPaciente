using GestorPaciente.Core.Application.ViewModels.Usuario;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IUsuarioService : IGenericService<SaveUsuarioViewModel, UsuarioViewModel, Usuario>
    {
        public Task<UsuarioViewModel> Login(LoginViewModel vm);

        public Task<bool> UserNameExists(string userName);
    }
}
