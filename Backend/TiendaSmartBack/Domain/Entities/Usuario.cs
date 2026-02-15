namespace TiendaSmartBack.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UsuarioPersonal { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Rol {  get; set; } = string.Empty;
        public int? IdCliente { get; set; }
        public Cliente? Cliente { get; set; }
        public ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
        public ICollection<CarritoArticulo> CarritoArticulos { get; set; } = new List<CarritoArticulo>();

    }
}
