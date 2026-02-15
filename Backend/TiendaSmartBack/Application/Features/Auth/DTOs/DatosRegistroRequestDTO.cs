namespace TiendaSmartBack.Application.Features.Auth.DTOs
{
    public class DatosRegistroRequestDTO
    {
        public string NombreCliente { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string? SegundoApellido { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string UsuarioPersonal { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
