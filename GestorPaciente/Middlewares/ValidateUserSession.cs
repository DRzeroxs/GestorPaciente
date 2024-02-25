using GestorPaciente.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;
using GestorPaciente.Core.Application.ViewModels.Usuario;
namespace GestorPaciente.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUserAdmin()
        {
            UsuarioViewModel usuarioViewModel = _httpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("user");

            if (usuarioViewModel == null)
            {
                return false;
            }

            if (!usuarioViewModel.Admin)
            {
                return false;
            }

            return true;
        }

        public bool HasUserAsistent()
        {
            UsuarioViewModel usuarioViewModel = _httpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("user");

            if (usuarioViewModel == null)
            {
                return false;
            }

            if (usuarioViewModel.Admin)
            {
                return false;
            }

            return true;
        }
    }
}
