using MediatR;
using TiendaSmartBack.Application.Features.Sucursal.Command;
using TiendaSmartBack.Application.Features.Sucursal.Policies;
using TiendaSmartBack.Application.Utils;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;
using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Features.Sucursal.Handlers
{
    public class DeshabilitaSucursalHandler
        :IRequestHandler<DeshabilitaSucursalCommand, ServiceResult<ResultadoOperacionDTO>>
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IUsuarioActivoService _usuarioActivoService;
        private readonly SucursalAccessService _access;

        public DeshabilitaSucursalHandler(ISucursalRepository sucursalRepository, 
            IUsuarioActivoService usuarioActivoService, SucursalAccessService access)
        {
            _sucursalRepository = sucursalRepository;
            _usuarioActivoService = usuarioActivoService;
            _access = access;
        }

        public async Task<ServiceResult<ResultadoOperacionDTO>> Handle(DeshabilitaSucursalCommand request, 
            CancellationToken cancellationToken)
        {
            if (_usuarioActivoService.Rol == null)
                return ServiceResult<ResultadoOperacionDTO>.Fail("Token inválido", ServiceStatusEnum.Unauthorized);

            if (!_access.PuedeCRUDSucursal(_usuarioActivoService.Rol))
                return ServiceResult<ResultadoOperacionDTO>.Fail("Rol no autorizado", ServiceStatusEnum.Forbidden);

            var resultadoRepositorio = await _sucursalRepository.DeshabilitarSucursal(request.IdSucursal, cancellationToken);

            var resultadoOperacionDTO = new ResultadoOperacionDTO();

            if (resultadoRepositorio == true)
            {
                resultadoOperacionDTO.Exito = true;
                resultadoOperacionDTO.Mensaje = "se deshabilito la sucursal con exitó.";
            }
            else
            {
                resultadoOperacionDTO.Exito = false;
                resultadoOperacionDTO.Mensaje = "no se puedo deshabilitar la sucursal";
            }

            return ServiceResult<ResultadoOperacionDTO>.Ok(resultadoOperacionDTO);
        }
    }
}
