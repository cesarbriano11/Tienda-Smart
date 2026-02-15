using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaSmartBack.Domain.Entities
{
    public class CarritoArticulo
    {
        public int IdCarritoArticulo { get; set; }
        public int IdCarrito { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public bool Habilitado { get; set; } = true;
        public decimal Precio { get; set; }
        public Carrito Carrito { get; set; }
        public Articulo Articulo { get; set; }
    }
}
