using MediatR;
using TiendaSmartBack.Application.Features.Articulos.DTOs;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Articulos.Commands
{
    public record InsertaArticuloCommand(DatosArticuloRequestDTO DatosArticulo)
        : IRequest<ServiceResult<ResultadoOperacionDTO>>;
}
