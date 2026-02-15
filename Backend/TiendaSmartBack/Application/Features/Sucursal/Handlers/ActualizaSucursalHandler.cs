using AutoMapper;
using MediatR;
using TiendaSmartBack.Application.Features.Sucursal.Command;
using TiendaSmartBack.Application.Features.Sucursal.Policies;
using TiendaSmartBack.Application.Utils;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Sucursal.Handlers
{
    public class ActualizaSucursalHandler
        :IRequestHandler<AcutalizaDatosSucursalCommand, ServiceResult<ResultadoOperacionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IUsuarioActivoService _usuarioActivoService;
        private readonly SucursalAccessService _access;

        public ActualizaSucursalHandler(IMapper mapper, ISucursalRepository sucursalRepository,
            IUsuarioActivoService usuarioActivoService, SucursalAccessService access)
        {
            _mapper = mapper;
            _sucursalRepository = sucursalRepository;
            _usuarioActivoService = usuarioActivoService;
            _access = access;
        }

        public async Task<ServiceResult<ResultadoOperacionDTO>> Handle(AcutalizaDatosSucursalCommand request,
            CancellationToken cancellationToken)
        {
            if (_usuarioActivoService.Rol == null)
                return ServiceResult<ResultadoOperacionDTO>.Fail("Token inválido", ServiceStatusEnum.Unauthorized);

            if (!_access.PuedeCRUDSucursal(_usuarioActivoService.Rol))
                return ServiceResult<ResultadoOperacionDTO>.Fail("Rol no autorizado", ServiceStatusEnum.Forbidden);

            var resultadoConsulta = await _sucursalRepository.ObtenerSucuralPorId(request.IdSucursal, cancellationToken);

            if (resultadoConsulta == null)
                return ServiceResult<ResultadoOperacionDTO>.Fail("No se encontro la sucursal", ServiceStatusEnum.NotFound);

            var sucursal = resultadoConsulta;

            _mapper.Map(request.DatosActualiza, sucursal);

            var resultadoActualiza = await _sucursalRepository.ActualizaSucursal(sucursal, cancellationToken);

            if (!resultadoActualiza)
                return ServiceResult<ResultadoOperacionDTO>.Fail("ocurrio un error en la actualizacion", ServiceStatusEnum.DatabaseError);

            var resultadoOperacionDTO = new ResultadoOperacionDTO();

            resultadoOperacionDTO.Exito = true;
            resultadoOperacionDTO.Mensaje = "se actualizo la sucursal con exitó.";

            return ServiceResult<ResultadoOperacionDTO>.Ok(resultadoOperacionDTO);
        }
    }
}
