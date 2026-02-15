using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaSmartBack.Domain.Entities
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Habilitado { get; set; } = true;
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; } = null!;
        public ICollection<CarritoArticulo> CarritoArticulos { get; set; } = new List<CarritoArticulo>();
    }
}
