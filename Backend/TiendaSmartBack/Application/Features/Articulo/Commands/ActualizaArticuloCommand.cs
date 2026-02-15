using MediatR;
using TiendaSmartBack.Application.Features.Articulo.DTOs;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Articulo.Commands
{
    public record ActualizaArticuloCommand(DatosArticuloActualizaDTO DatosArticulo, int IdArticulo)
        : IRequest<ServiceResult<ResultadoOperacionDTO>>;
}
