namespace TiendaSmartBack.Domain.Entities
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool Habilitado { get; set; }
        public ICollection<SucursalArticulo> SucursalArticulos { get; set; }
    }
}
