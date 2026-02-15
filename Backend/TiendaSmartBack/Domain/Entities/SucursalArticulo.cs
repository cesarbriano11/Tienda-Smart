namespace TiendaSmartBack.Domain.Entities
{
    public class SucursalArticulo
    {
        public int IdSucursalArticulo { get; set; }
        public int IdSucursal {  get; set; }
        public Sucursal Sucursal { get; set; }
        public int IdArticulo { get; set; }
        public Articulo Articulo { get; set; }
        public int Stock { get; set; }
        public DateTime FechaAdquirido { get; set; }
    }
}
