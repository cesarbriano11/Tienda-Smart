using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaSmartBack.Application.Features.Articulos.Commands;
using TiendaSmartBack.Application.Features.Articulos.DTOs;
using TiendaSmartBack.Application.Features.Carrito.Command;
using TiendaSmartBack.Application.Features.Carrito.DTOs;

namespace TiendaSmartBack.Api.Controllers
{
    [Route("carrito")]
    [ApiController]
    [Authorize]
    public class CarritoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CarritoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> IsertarArticuloAlCarrito([FromBody] DatosCarritoRequestDTO datosArticulo, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new InsertaArticuloCarritoCommand(datosArticulo), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }


    }
}
