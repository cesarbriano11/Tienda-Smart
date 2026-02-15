using MediatR;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Articulo.Commands
{
    public record DeshabilitaArticuloCommand(int IdArticulo)
        : IRequest<ServiceResult<ResultadoOperacionDTO>>;
}
