using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TiendaSmartBack.Application.Features.Carrito.DTOs;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Domain.Entities;
using TiendaSmartBack.Infraestructure.Persistence;

namespace TiendaSmartBack.Infraestructure.Repositorios
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly ConexionDbContext _context;

        public CarritoRepository(ConexionDbContext context)
        {
            _context = context;
        }

        public async Task InsertarCarrito(Carrito carrito,CancellationToken cancellationToken)
        {
            _context.Carritos.Add(carrito);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task InsertarArticuloAlCarro(CarritoArticulo carritoArticulo, CancellationToken cancellationToken)
        {
            _context.CarritoArticulos.Add(carritoArticulo);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task ActualizaArticuloEnCarrito(CarritoArticulo carritoArticulo, CancellationToken cancellationToken)
        {
            _context.CarritoArticulos.Update(carritoArticulo);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
