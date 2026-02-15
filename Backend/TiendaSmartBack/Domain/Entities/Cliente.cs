namespace TiendaSmartBack.Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string PrimerApellido {  get; set; } = string.Empty;
        public string? SegundoApellido { get; set; }
        public string Direccion { get; set; } = string.Empty;   
        public Usuario? Usuario { get; set; }
    }
}
