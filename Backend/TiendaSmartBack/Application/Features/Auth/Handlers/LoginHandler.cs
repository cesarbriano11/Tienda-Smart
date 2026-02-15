using MediatR;
using TiendaSmartBack.Application.Features.Auth.commands;
using TiendaSmartBack.Application.Features.Auth.DTOs;
using TiendaSmartBack.Application.Utils;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Options;
using TiendaSmartBack.Application.Utils.Responses;
using TiendaSmartBack.Application.Utils.Security;

namespace TiendaSmartBack.Application.Features.Auth.Handlers
{
    public class LoginHandler
        :IRequestHandler<LoginCommand, ServiceResult<RespuestaAutentificacionDTO>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtOptions _jwtOptions;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginHandler(IUsuarioRepository usuarioRepository, JwtOptions jwtOptions, 
            IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtOptions = jwtOptions;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<ServiceResult<RespuestaAutentificacionDTO>> Handle(LoginCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var resultadoRepositorio = await _usuarioRepository.ObtenerUsuario(request.loginRequest.UsuarioPersonal
                    , cancellationToken);

                if (resultadoRepositorio == null)
                    return ServiceResult<RespuestaAutentificacionDTO>.Fail("Credenciales incorrectas", Utils.ServiceStatusEnum.NotFound);

                var passwordHash = HashHelper.GetMd5Hash(request.loginRequest.Password.Trim());

                if(resultadoRepositorio.PasswordHash != passwordHash)
                    return ServiceResult<RespuestaAutentificacionDTO>.Fail("Credenciales incorrectas", Utils.ServiceStatusEnum.NotFound);

                var accessToken = _jwtTokenService.ConstruirAccessToken(resultadoRepositorio);

                return ServiceResult<RespuestaAutentificacionDTO>.Ok(
                    new RespuestaAutentificacionDTO
                    {
                        Token = accessToken
                    }
               );
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return ServiceResult<RespuestaAutentificacionDTO>.Fail("Ocurrio un error en el servidor", ServiceStatusEnum.InternalError);
            }
        }
    }
}
