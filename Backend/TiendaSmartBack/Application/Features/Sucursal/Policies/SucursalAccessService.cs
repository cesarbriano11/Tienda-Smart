namespace TiendaSmartBack.Application.Features.Sucursal.Policies
{
    public class SucursalAccessService
    {
        public bool PuedeCRUDSucursal(string Rol) 
        {
            return Rol == "Admin";
        }
    }
}
