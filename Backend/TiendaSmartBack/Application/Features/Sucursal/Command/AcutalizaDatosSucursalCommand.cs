using MediatR;
using TiendaSmartBack.Application.Features.Sucursal.DTOs;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Sucursal.Command
{
    public record AcutalizaDatosSucursalCommand(DatosSucursalActualizaDTO DatosActualiza, int IdSucursal)
        : IRequest<ServiceResult<ResultadoOperacionDTO>>;
}
