namespace TiendaSmartBack.Domain.Entities
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string UrlImagen {  get; set; } = string.Empty;
        public bool Habilitado { get; set; }
        public ICollection<SucursalArticulo> SucursalArticulos { get; set; }
        public ICollection<Carrito> Carritos { get; set; }
        public ICollection<CarritoArticulo> CarritoArticulos { get; set; } 

    }
}
