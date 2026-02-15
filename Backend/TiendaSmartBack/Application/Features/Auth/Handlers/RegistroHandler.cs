using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration.UserSecrets;
using TiendaSmartBack.Application.Features.Auth.commands;
using TiendaSmartBack.Application.Utils;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;
using TiendaSmartBack.Application.Utils.Security;
using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Features.Auth.Handlers
{
    public class RegistroHandler
        :IRequestHandler<RegistroCommand, ServiceResult<ResultadoOperacionDTO>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public RegistroHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ResultadoOperacionDTO>> Handle(RegistroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existe = await _usuarioRepository.ExisteUsuario(request.DatosRegistro.UsuarioPersonal, cancellationToken);

                if (existe)
                    return ServiceResult<ResultadoOperacionDTO>.Fail("El usuario ya existe", Utils.ServiceStatusEnum.BadRequest);


                var clienteDTO = _mapper.Map<Cliente>(request.DatosRegistro);

                var usuarioDTO = _mapper.Map<Usuario>(request.DatosRegistro);

                usuarioDTO.PasswordHash = HashHelper.GetMd5Hash(request.DatosRegistro.Password);

                var resultadoRepositorio = await _usuarioRepository.RegistroCliente(usuarioDTO, clienteDTO, cancellationToken);


                var resultadoOperacionDTO = new ResultadoOperacionDTO();

                if (resultadoRepositorio != null)
                {
                    resultadoOperacionDTO.Exito = true;
                    resultadoOperacionDTO.Mensaje = "se inserto el usuario con exitó.";
                }

                return ServiceResult<ResultadoOperacionDTO>.Ok(resultadoOperacionDTO);
            }
            catch (Exception ex) 
            {
                string error = ex.Message;
                return ServiceResult<ResultadoOperacionDTO>.Fail(error, Utils.ServiceStatusEnum.InternalError);
            }
        }
    }
}
