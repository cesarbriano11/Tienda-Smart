namespace TiendaSmartBack.Application.Features.Auth.DTOs
{
    public class LoginRequestDTO
    {
        public string UsuarioPersonal { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
    }
}
