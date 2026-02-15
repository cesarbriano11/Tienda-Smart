using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Utils.Interfaces
{
    public interface ISucursalRepository
    {
        Task<Sucursal> InsertaSucursal(Sucursal sucursal, CancellationToken cancellationToken);
        Task<List<Sucursal>> ConsultaSucursalesActivas(CancellationToken cancellationToken);
        Task<Sucursal?> ObtenerSucuralPorId(int idSucursal, CancellationToken cancellationToken);
        Task<bool> ActualizaSucursal(Sucursal sucursal, CancellationToken cancellationToken);
        Task<bool> DeshabilitarSucursal(int idSucursal, CancellationToken cancellationToken);
    }
}