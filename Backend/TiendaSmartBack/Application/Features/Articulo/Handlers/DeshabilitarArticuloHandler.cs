using MediatR;
using TiendaSmartBack.Application.Features.Articulo.Commands;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Articulo.Handlers
{
    public class DeshabilitarArticuloHandler
        :IRequestHandler<DeshabilitaArticuloCommand, ServiceResult<ResultadoOperacionDTO>>
    {
        private readonly IArticuloRepository _articuloRepository;

        public DeshabilitarArticuloHandler(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task<ServiceResult<ResultadoOperacionDTO>> Handle(DeshabilitaArticuloCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var articulo = await _articuloRepository.ConsultaArticuloPorId(request.IdArticulo, cancellationToken);

                if (articulo == null)
                    return ServiceResult<ResultadoOperacionDTO>.Fail("Articulo no encontrado", Utils.ServiceStatusEnum.NotFound);

                articulo.Habilitado = false;

                await _articuloRepository.GuardarArticulo(cancellationToken);

                var resultadoOperacionDTO = new ResultadoOperacionDTO
                {
                    Exito = true,
                    Mensaje = "se inserto el articulo con exitó."
                };
                return ServiceResult<ResultadoOperacionDTO>.Ok(resultadoOperacionDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<ResultadoOperacionDTO>.Fail(ex.Message, Utils.ServiceStatusEnum.InternalError);
            }
        }
    }
}


