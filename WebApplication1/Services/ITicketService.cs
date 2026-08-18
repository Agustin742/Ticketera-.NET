using WebApplication1.Dtos;

namespace WebApplication1.Services
{
    public interface ITicketService
    {
        Task<List<TicketDto>> ObtenerTodosAsync();
        Task<TicketDto?> ObtenerPorIdAsync(int id);
        Task<TicketDto> CrearAsync(CrearTicketDto dto);
        Task<bool> ActualizarAsync(int id, ActualizarTicketDto dto);
        Task<bool> EliminarAsync(int id);
    }
}
