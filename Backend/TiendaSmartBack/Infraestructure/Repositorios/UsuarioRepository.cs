using Microsoft.EntityFrameworkCore;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Domain.Entities;
using TiendaSmartBack.Infraestructure.Persistence;

namespace TiendaSmartBack.Infraestructure.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConexionDbContext _context;

        public UsuarioRepository(ConexionDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> RegistroCliente(Usuario usuario, Cliente cliente, CancellationToken cancellationToken)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync(cancellationToken);

            usuario.IdCliente = cliente.IdCliente;
            usuario.Rol = "Cliente";

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync(cancellationToken);

            return usuario;

        }

        public async Task<bool> ExisteUsuario(string usuarioPersona, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.AnyAsync(u => u.UsuarioPersonal == usuarioPersona, cancellationToken);
        }

        public async Task<Usuario?> ObtenerUsuario(string usuarioPersonal, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.Include(u => u.Cliente)
                .FirstOrDefaultAsync(u => u.UsuarioPersonal == usuarioPersonal, cancellationToken);
        }

        public async Task AddSync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
