namespace TiendaSmartBack.Application.Features.Articulo.DTOs
{
    public class ResArticulosPorSucursalDTO
    {
        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string UrlImagen { get; set; } = string.Empty;
        public int IdSucursal { get; set; }
        public int Stock { get; set; }
    }
}
