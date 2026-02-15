using MediatR;
using TiendaSmartBack.Application.Features.Carrito.DTOs;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Carrito.Command
{
    public record InsertaArticuloCarritoCommand(DatosCarritoRequestDTO DatosCarrito)
        : IRequest<ServiceResult<ResultadoOperacionDTO>>;
}
