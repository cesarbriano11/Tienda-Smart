using MediatR;
using TiendaSmartBack.Application.Features.Carrito.Command;
using TiendaSmartBack.Application.Features.Carrito.DTOs;
using TiendaSmartBack.Application.Utils.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Application.Utils.Responses;
using TiendaSmartBack.Domain.Entities;
using TiendaSmartBack.Infraestructure.Repositorios;

namespace TiendaSmartBack.Application.Features.Carrito.Handlers
{
    public class InsertaArticuloCarritoHandler
        :IRequestHandler<InsertaArticuloCarritoCommand, ServiceResult<ResultadoOperacionDTO>>
    {
        private readonly ICarritoRepository _carritoRepository;
        private readonly IUsuarioActivoService _usuarioActivoService;
        private readonly IArticuloRepository _articuloRepository;

        public InsertaArticuloCarritoHandler(ICarritoRepository carritoRepository,
            IUsuarioActivoService usuarioActivoService, IArticuloRepository articuloRepository)
        {
            _carritoRepository = carritoRepository;
            _usuarioActivoService = usuarioActivoService;
            _articuloRepository = articuloRepository;

        }

        public async Task<ServiceResult<ResultadoOperacionDTO>> Handle(InsertaArticuloCarritoCommand request,
            CancellationToken cancellationToken)
        {
            var resultadoOperacionDTO = new ResultadoOperacionDTO
            {
                Exito = true,
                Mensaje = "Se agregó al carrito."
            };

            return ServiceResult<ResultadoOperacionDTO>.Ok(resultadoOperacionDTO);
        }
    }
}
