namespace TiendaSmartBack.Application.Features.Carrito.DTOs
{
    public class CarritoDto
    {
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Habilitado { get; set; }

        public List<CarritoArticuloDto> Articulos { get; set; } = new();
    }

    public class CarritoArticuloDto
    {
        public int IdCarritoArticulo { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Habilitado { get; set; }

        public string NombreArticulo { get; set; } = string.Empty;
    }

}
