using MediatR;
using TiendaSmartBack.Application.Features.Articulo.Commands;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;

namespace TiendaSmartBack.Application.Features.Articulo.Handlers
{
    public class ActualizaArticulosHandler
        :IRequestHandler<ActualizaArticuloCommand, ServiceResult<ResultadoOperacionDTO>>
    {
        private readonly IArticuloRepository _articuloRepository;

        public ActualizaArticulosHandler(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task<ServiceResult<ResultadoOperacionDTO>> Handle(ActualizaArticuloCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var datos = request.DatosArticulo;

                var articulo = await _articuloRepository.ConsultaArticuloPorId(request.IdArticulo, cancellationToken);

                if (articulo == null)
                    return ServiceResult<ResultadoOperacionDTO>.Fail("Articulo no encontrado", Utils.ServiceStatusEnum.NotFound);

                articulo.NombreArticulo = datos.NombreArticulo;
                articulo.Codigo = datos.Codigo;
                articulo.Descripcion = datos.Descripcion;
                articulo.Precio = datos.Precio;
                articulo.UrlImagen = datos.UrlImagen;

                var sucursalArticulo = articulo.SucursalArticulos.FirstOrDefault(x => x.IdSucursal == datos.IdSucursal);

                if (sucursalArticulo == null)
                    return ServiceResult<ResultadoOperacionDTO>.Fail("ocrrio un error en la base de datos", Utils.ServiceStatusEnum.DatabaseError);

                sucursalArticulo.Stock = datos.Stock;

                await _articuloRepository.GuardarArticulo(cancellationToken);

                var resultadoOperacionDTO = new ResultadoOperacionDTO();

                resultadoOperacionDTO.Exito = true;
                resultadoOperacionDTO.Mensaje = "se inserto el articulo con exitó.";
                return ServiceResult<ResultadoOperacionDTO>.Ok(resultadoOperacionDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<ResultadoOperacionDTO>.Fail(ex.Message, Utils.ServiceStatusEnum.InternalError);
            }
        }
    }
}
