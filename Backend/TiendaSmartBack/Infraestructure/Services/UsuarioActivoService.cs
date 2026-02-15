using System.Security.Claims;
using TiendaSmartBack.Application.Utils.Interfaces;

namespace TiendaSmartBack.Infraestructure.Services
{
    public class UsuarioActivoService : IUsuarioActivoService
    {
        public int? IdUsuario { get; }
        public string? Rol { get; }

        public UsuarioActivoService(IHttpContextAccessor httpContextAccessor)
        {
            var ClaimValueId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(ClaimValueId, out var id))
                IdUsuario = id;
            else
                IdUsuario = null;

            var usuario = httpContextAccessor.HttpContext?.User;

            Rol = usuario?.FindFirst(ClaimTypes.Role)?.Value;
        }
    }
}
