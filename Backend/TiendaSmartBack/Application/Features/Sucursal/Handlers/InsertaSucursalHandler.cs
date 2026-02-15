using AutoMapper;
using MediatR;
using TiendaSmartBack.Application.Features.Sucursal.Command;
using TiendaSmartBack.Application.Features.Sucursal.Policies;
using TiendaSmartBack.Application.Utils;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;
using TiendaSmartBack.Infraestructure.Repositorios;

namespace TiendaSmartBack.Application.Features.Sucursal.Handlers
{
    public class InsertaSucursalHandler
        :IRequestHandler<InsertaSucursalCommand, ServiceResult<ResultadoOperacionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IUsuarioActivoService _usuarioActivoService;
        private readonly SucursalAccessService _access;


        public InsertaSucursalHandler(IMapper mapper, ISucursalRepository sucursalRepository, 
            IUsuarioActivoService usuarioActivoService, SucursalAccessService access)
        {
            _mapper = mapper;
            _sucursalRepository = sucursalRepository;
            _usuarioActivoService = usuarioActivoService;
            _access = access;
        }

        public async Task<ServiceResult<ResultadoOperacionDTO>> Handle(InsertaSucursalCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if(_usuarioActivoService.Rol == null)
                    return ServiceResult<ResultadoOperacionDTO>.Fail("Token inválido", ServiceStatusEnum.Unauthorized);

                if(!_access.PuedeCRUDSucursal(_usuarioActivoService.Rol))
                    return ServiceResult<ResultadoOperacionDTO>.Fail("Rol no autorizado", ServiceStatusEnum.Forbidden);


                var sucursal = _mapper.Map<Domain.Entities.Sucursal>(request.DatosSucursalRequestDTO);

                var resultadoRepositorio = await _sucursalRepository.InsertaSucursal(sucursal, cancellationToken);


                var resultadoOperacionDTO = new ResultadoOperacionDTO();

                if (resultadoRepositorio != null)
                {
                    resultadoOperacionDTO.Exito = true;
                    resultadoOperacionDTO.Mensaje = "se inserto la sucursal con exitó.";
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
