namespace TiendaSmartBack.Application.Features.Sucursal.DTOs
{
    public class ResSucursalesActivasDTO
    {
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool Habilitado { get; set; }
    }
}
