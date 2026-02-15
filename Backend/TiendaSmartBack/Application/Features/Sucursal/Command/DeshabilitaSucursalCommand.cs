using MediatR;
using MediatR.Registration;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Sucursal.Command
{
    public record DeshabilitaSucursalCommand(int IdSucursal)
        : IRequest<ServiceResult<ResultadoOperacionDTO>>;
}
