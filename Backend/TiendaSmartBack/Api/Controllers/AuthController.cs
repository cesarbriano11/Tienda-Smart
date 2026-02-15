using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaSmartBack.Application.Features.Auth.commands;
using TiendaSmartBack.Application.Features.Auth.DTOs;

namespace TiendaSmartBack.Api.Controllers
{

    [Route("auth")]
    [ApiController]

    public class AuthController: ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("registro")]
        public async Task<IActionResult> RegistroUsuario([FromBody] DatosRegistroRequestDTO datosRegistro, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new RegistroCommand(datosRegistro), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginRequestDTO loginRequest, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new LoginCommand(loginRequest), cancellationToken);

            if (!resultado.Success)
                return StatusCode((int)resultado.Status, new
                {
                    error = resultado.ErrorMessage,
                });

            return Ok(resultado.Data);
        }
    }
}
