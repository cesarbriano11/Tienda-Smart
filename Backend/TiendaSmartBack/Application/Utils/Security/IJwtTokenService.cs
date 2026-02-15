

using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Utils.Security
{
    public interface IJwtTokenService
    {

        string ConstruirAccessToken(Usuario usuario);
    }
}