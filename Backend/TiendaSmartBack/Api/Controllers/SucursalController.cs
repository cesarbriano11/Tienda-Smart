using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaSmartBack.Application.Features.Auth.commands;
using TiendaSmartBack.Application.Features.Auth.DTOs;
using TiendaSmartBack.Application.Features.Sucursal.Command;
using TiendaSmartBack.Application.Features.Sucursal.DTOs;
using TiendaSmartBack.Application.Features.Sucursal.Queries;

namespace TiendaSmartBack.Api.Controllers
{

    [Route("sucursal")]
    [ApiController]
    [Authorize]
    public class SucursalController: ControllerBase
    {

        private readonly IMediator _mediator;

        public SucursalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearSucursal([FromBody] DatosSucursalRequestDTO datosSucursal, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new InsertaSucursalCommand(datosSucursal), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaSucursalesActivas(CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new ConsultaSucursalesQuery(), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }

        [HttpPut]
        [Route("{idSucursal}")]

        public async Task<IActionResult> actualizaSucursal([FromBody] DatosSucursalActualizaDTO datosActualiza, 
            int idSucursal ,CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new AcutalizaDatosSucursalCommand(datosActualiza, idSucursal), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }

        [HttpDelete]
        [Route("{idSucursal}")]

        public async Task<IActionResult> DeshabilitaSucursal(int idSucursal, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new DeshabilitaSucursalCommand(idSucursal), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }
    }
}
