using AutoMapper;
using MediatR;
using TiendaSmartBack.Application.Features.Sucursal.DTOs;
using TiendaSmartBack.Application.Features.Sucursal.Policies;
using TiendaSmartBack.Application.Features.Sucursal.Queries;
using TiendaSmartBack.Application.Utils;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;
using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Features.Sucursal.Handlers
{
    public class ConsultaSucursalesHandler
        :IRequestHandler<ConsultaSucursalesQuery, ServiceResult<List<ResSucursalesActivasDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IUsuarioActivoService _usuarioActivoService;
        private readonly SucursalAccessService _access;

        public ConsultaSucursalesHandler(IMapper mapper, 
            ISucursalRepository sucursalRepository, IUsuarioActivoService usuarioActivoService, 
            SucursalAccessService access)
        {
            _mapper = mapper;
            _sucursalRepository = sucursalRepository;
            _usuarioActivoService = usuarioActivoService;
            _access = access;
        }

        public async Task<ServiceResult<List<ResSucursalesActivasDTO>>> Handle(ConsultaSucursalesQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                if (_usuarioActivoService.Rol == null)
                    return ServiceResult<List<ResSucursalesActivasDTO>>.Fail("Token inválido", ServiceStatusEnum.Unauthorized);

                if (!_access.PuedeCRUDSucursal(_usuarioActivoService.Rol))
                    return ServiceResult<List<ResSucursalesActivasDTO>>.Fail("Rol no autorizado", ServiceStatusEnum.Forbidden);

                var resultadoRepositorio = await _sucursalRepository.ConsultaSucursalesActivas(cancellationToken);

                List<ResSucursalesActivasDTO> sucursalesActivas;
                sucursalesActivas =[.. _mapper.Map<List<ResSucursalesActivasDTO>>(resultadoRepositorio)];

                return ServiceResult<List<ResSucursalesActivasDTO>>.Ok(sucursalesActivas);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return ServiceResult<List<ResSucursalesActivasDTO>>.Fail(error, Utils.ServiceStatusEnum.InternalError);
            }
        }
    }
}
