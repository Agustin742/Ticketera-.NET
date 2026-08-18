namespace WebApplication1.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public EstadoTicket Estado { get; set; } = EstadoTicket.ABIERTO;
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
        
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
