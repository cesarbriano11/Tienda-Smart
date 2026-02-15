using MediatR;
using TiendaSmartBack.Application.Features.Articulos.Commands;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;
using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Features.Articulos.Handlers
{
    public class InsertaArticuloHandler
        :IRequestHandler<InsertaArticuloCommand, ServiceResult<ResultadoOperacionDTO>>
    {
        private readonly IArticuloRepository _articuloRepository;

        public InsertaArticuloHandler(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task<ServiceResult<ResultadoOperacionDTO>> Handle(InsertaArticuloCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var datos = request.DatosArticulo;

                var articulo = new Domain.Entities.Articulo
                {
                    NombreArticulo = datos.NombreArticulo,
                    Codigo = datos.Codigo,
                    Descripcion = datos.Descripcion,
                    Precio = datos.Precio,
                    UrlImagen = datos.UrlImagen,
                    Habilitado = true
                };

                var sucursalArticulo = new SucursalArticulo
                {
                    IdSucursal = datos.IdSucursal,
                    Stock = datos.Stock,
                    FechaAdquirido = DateTime.UtcNow
                };

                articulo.SucursalArticulos = new List<SucursalArticulo>
                {
                sucursalArticulo
                };

                await _articuloRepository.InsertArticulo(articulo, cancellationToken);

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
