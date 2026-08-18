namespace WebApplication1.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
