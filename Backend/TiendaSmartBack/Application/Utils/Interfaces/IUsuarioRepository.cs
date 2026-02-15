using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Utils.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AddSync(Usuario usuario);
        Task<Usuario> RegistroCliente(Usuario usuario, Cliente cliente, CancellationToken cancellationToken);
        Task<bool> ExisteUsuario(string usuarioPersona, CancellationToken cancellationToken);
        Task<Usuario?> ObtenerUsuario(string usuarioPersonal, CancellationToken cancellationToken);
        Task SaveChangesAsync();
    }
}