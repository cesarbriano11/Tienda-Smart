using MediatR;
using TiendaSmartBack.Application.Features.Sucursal.DTOs;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Sucursal.Command
{
    public record InsertaSucursalCommand(DatosSucursalRequestDTO DatosSucursalRequestDTO)
        : IRequest<ServiceResult<ResultadoOperacionDTO>>;
}
