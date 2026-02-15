using MediatR;
using TiendaSmartBack.Application.Features.Auth.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Auth.commands
{
    public record LoginCommand(LoginRequestDTO loginRequest)
        :IRequest<ServiceResult<RespuestaAutentificacionDTO>>;
}
