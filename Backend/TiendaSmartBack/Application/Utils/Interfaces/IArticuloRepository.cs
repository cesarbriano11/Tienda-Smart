using Microsoft.EntityFrameworkCore;
using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Utils.Interfaces
{
    public interface IArticuloRepository
    {
        Task InsertArticulo(Articulo articulo, CancellationToken cancellationToken);
        Task<List<SucursalArticulo>> consultaArticulos(int idSucursal, CancellationToken cancellationToken);
        Task<Articulo?> ConsultaArticuloPorId(int idArticulo, CancellationToken cancellationToken);

        Task GuardarArticulo(CancellationToken cancellationToken);
    }
}