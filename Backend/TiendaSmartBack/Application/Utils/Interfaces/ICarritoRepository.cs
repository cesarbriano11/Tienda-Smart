using Microsoft.EntityFrameworkCore;
using TiendaSmartBack.Application.Features.Carrito.DTOs;
using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Utils.Interfaces
{
    public interface ICarritoRepository
    {

        Task InsertarCarrito(Carrito carrito, CancellationToken cancellationToken);
        Task InsertarArticuloAlCarro(CarritoArticulo carritoArticulo, CancellationToken cancellationToken);
        Task ActualizaArticuloEnCarrito(CarritoArticulo carritoArticulo, CancellationToken cancellationToken);
    }
}