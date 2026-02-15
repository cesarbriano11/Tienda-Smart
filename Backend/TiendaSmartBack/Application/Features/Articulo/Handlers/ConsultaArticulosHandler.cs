using AutoMapper;
using MediatR;
using MediatR.Registration;
using TiendaSmartBack.Application.Features.Articulo.DTOs;
using TiendaSmartBack.Application.Features.Articulo.Queries;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Articulo.Handlers
{
    public class ConsultaArticulosHandler
        :IRequestHandler<ConsultaArticulosQuery, ServiceResult<List<ResArticulosPorSucursalDTO>>>
    {
        private readonly IArticuloRepository _articuloRepository;
        private readonly IMapper _mapper;

        public ConsultaArticulosHandler(IArticuloRepository articuloRepository, IMapper mapper)
        {
            _articuloRepository = articuloRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<ResArticulosPorSucursalDTO>>> Handle(ConsultaArticulosQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                var articulos = await _articuloRepository.consultaArticulos(query.IdSucursal, cancellationToken);

                List<ResArticulosPorSucursalDTO> resultadoDTO;
                resultadoDTO = [.. _mapper.Map<List<ResArticulosPorSucursalDTO>>(articulos)];

                return ServiceResult<List<ResArticulosPorSucursalDTO>>.Ok(resultadoDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ResArticulosPorSucursalDTO>>.Fail(ex.Message, Utils.ServiceStatusEnum.InternalError);
            }
        }
    }
}
