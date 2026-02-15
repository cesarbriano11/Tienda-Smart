using Microsoft.EntityFrameworkCore;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Domain.Entities;
using TiendaSmartBack.Infraestructure.Persistence;

namespace TiendaSmartBack.Infraestructure.Repositorios
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly ConexionDbContext _context;

        public SucursalRepository(ConexionDbContext context)
        {
            _context = context;
        }

        public async Task<Sucursal> InsertaSucursal(Sucursal sucursal, CancellationToken cancellationToken)
        {
            await _context.Sucursales.AddAsync(sucursal);
            await _context.SaveChangesAsync(cancellationToken);

            return sucursal;


        }

        public async Task<List<Sucursal>> ConsultaSucursalesActivas(CancellationToken cancellationToken)
        {
            return await _context.Sucursales.Where(x => x.Habilitado).ToListAsync(cancellationToken);
        } 

        public async Task<Sucursal?> ObtenerSucuralPorId(int idSucursal, CancellationToken cancellationToken)
        {
            return await _context.Sucursales.FirstOrDefaultAsync(x => x.IdSucursal == idSucursal && x.Habilitado);
        }

        public async Task<bool> ActualizaSucursal(Sucursal sucursal, CancellationToken cancellationToken)
        {
            _context.Sucursales.Update(sucursal);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeshabilitarSucursal(int idSucursal, CancellationToken cancellationToken)
        {
            var sucursal = await _context.Sucursales.FirstOrDefaultAsync(
                x => x.IdSucursal == idSucursal, cancellationToken);

            if (sucursal == null)
                return false;

            sucursal.Habilitado = false;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
