using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaSmartBack.Application.Features.Articulo.Commands;
using TiendaSmartBack.Application.Features.Articulo.DTOs;
using TiendaSmartBack.Application.Features.Articulo.Queries;
using TiendaSmartBack.Application.Features.Articulos.Commands;
using TiendaSmartBack.Application.Features.Articulos.DTOs;
using TiendaSmartBack.Application.Features.Sucursal.Command;
using TiendaSmartBack.Application.Features.Sucursal.DTOs;

namespace TiendaSmartBack.Api.Controllers
{

    [Route("articulo")]
    [ApiController]
    [Authorize]
    public class ArticuloController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticuloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearArticulo([FromBody] DatosArticuloRequestDTO datosArticulo, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new InsertaArticuloCommand(datosArticulo), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }

        [HttpGet]
        [Route("sucursal/{idSucursal}")]
        public async Task<IActionResult> ConsultarArticulo(int idSucursal, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new ConsultaArticulosQuery(idSucursal), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }

        [HttpPut]
        [Route("{idArticulo}")]
        public async Task<IActionResult> ActualizaArticulo([FromBody] DatosArticuloActualizaDTO datosActualizar, int idArticulo, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new ActualizaArticuloCommand(datosActualizar, idArticulo), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }

        [HttpDelete]
        [Route("{idArticulo}")]

        public async Task<IActionResult> DeshabilitaArticulo(int idArticulo, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new DeshabilitaArticuloCommand(idArticulo), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }
    }
}
