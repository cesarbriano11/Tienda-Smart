using Microsoft.EntityFrameworkCore;
using TiendaSmartBack.Application.Utils.Interfaces;
using TiendaSmartBack.Domain.Entities;
using TiendaSmartBack.Infraestructure.Persistence;

namespace TiendaSmartBack.Infraestructure.Repositorios
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ConexionDbContext _context;

        public ArticuloRepository(ConexionDbContext context)
        {
            _context = context;
        }

        public async Task InsertArticulo(Articulo articulo, CancellationToken cancellationToken)
        {
            _context.Articulo.Add(articulo);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<SucursalArticulo>> consultaArticulos(int idSucursal, CancellationToken cancellationToken)
        {
            return await _context.SucursalArticulos.Include(x => x.Articulo).
                Where(x => x.IdSucursal == idSucursal && x.Articulo.Habilitado == true)
                .AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Articulo?> ConsultaArticuloPorId(int idArticulo, CancellationToken cancellationToken)
        {
            return await _context.Articulo.Include(x => x.SucursalArticulos)
                .FirstOrDefaultAsync(x => x.IdArticulo == idArticulo, cancellationToken);
        }

        public async Task GuardarArticulo(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
