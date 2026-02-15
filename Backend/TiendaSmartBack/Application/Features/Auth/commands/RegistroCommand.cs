using MediatR;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Features.Auth.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Auth.commands
{
    public record RegistroCommand(DatosRegistroRequestDTO DatosRegistro)
        :IRequest<ServiceResult<ResultadoOperacionDTO>>;

}
