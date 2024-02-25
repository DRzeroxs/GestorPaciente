using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.ViewModels.Usuario;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context) : base(context)
        {   
            _context = context;
        }

        public override async Task<Usuario> AddAsync(Usuario entity)
        {
            entity.Password = PasswordEncryptation.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);
            return entity;
        }

        public override async Task UpdateAsync(Usuario entity, int id)
        {
            Usuario entry = await _context.Set<Usuario>().FindAsync(id);

            entity.Password = PasswordEncryptation.ComputeSha256Hash(entity.Password);


            if (entry != null)
            {
                _context.Entry(entry).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Usuario> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypt = PasswordEncryptation.ComputeSha256Hash(loginVm.Password);
            Usuario usuario = await _context.Set<Usuario>().FirstOrDefaultAsync(user => user.UserName == loginVm.Username && user.Password == passwordEncrypt);
            return usuario;
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            return await _context.Usuarios.AnyAsync(u => u.UserName == userName);
        }
    }
}
