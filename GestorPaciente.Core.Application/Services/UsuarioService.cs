using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Usuario;
using GestorPaciente.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorPaciente.Core.Application.Services
{
    public class UsuarioService : GenericService<SaveUsuarioViewModel, UsuarioViewModel, Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioViewModel> Login(LoginViewModel vm)
        {
            Usuario user = await _repository.LoginAsync(vm);

            if (user == null)
            {
                return null;
            }

            UsuarioViewModel userVm = _mapper.Map<UsuarioViewModel>(user);

            return userVm;

        }

        public async Task<bool> UserNameExists(string userName)
        {
            return await _repository.UserNameExistsAsync(userName);
        }

    }
}
