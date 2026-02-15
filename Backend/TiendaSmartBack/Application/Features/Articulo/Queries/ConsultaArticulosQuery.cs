using MediatR;
using TiendaSmartBack.Application.Features.Articulo.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Articulo.Queries
{
    public record ConsultaArticulosQuery(int IdSucursal)
        : IRequest<ServiceResult<List<ResArticulosPorSucursalDTO>>>;
}
