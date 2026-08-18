using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _db;
        public TicketService(AppDbContext db) => _db = db;

        public async Task<List<TicketDto>> ObtenerTodosAsync() =>
            await _db.Tickets
                .AsNoTracking()
                .Include(t => t.Usuario)
                .OrderByDescending(t => t.CreadoEn)
                .Select(t => new TicketDto(
                        t.Id,
                        t.Titulo,
                        t.Descripcion,
                        t.Estado,
                        t.CreadoEn,
                        t.Usuario!.Nombre
                    ))
                .ToListAsync();

        public async Task<TicketDto?> ObtenerPorIdAsync(int id) =>
            await _db.Tickets
                .AsNoTracking()
                .Include(t => t.Usuario)
                .Where(t => t.Id == id)
                .Select(t => new TicketDto(
                        t.Id,
                        t.Titulo,
                        t.Descripcion,
                        t.Estado,
                        t.CreadoEn,
                        t.Usuario!.Nombre
                    ))
                .FirstOrDefaultAsync();

        public async Task<TicketDto> CrearAsync(CrearTicketDto dto)
        {
            var ticket = new Ticket
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                UsuarioId = dto.UsuarioId
            };

            _db.Add(ticket);
            await _db.SaveChangesAsync();

            var usuario = await _db.Usuarios.FindAsync(dto.UsuarioId);
            return new TicketDto(
                ticket.Id,
                ticket.Titulo,
                ticket.Descripcion,
                ticket.Estado,
                ticket.CreadoEn,
                usuario!.Nombre
            );
        }

        public async Task<bool> ActualizarAsync(int id, ActualizarTicketDto dto)
        {
            var ticket = await _db.Tickets.FindAsync(id);
            
            if (ticket == null) return false;

            ticket.Titulo = dto.Titulo;
            ticket.Descripcion = dto.Descripcion;
            ticket.Estado = dto.Estado;

            await _db.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var ticket = await _db.Tickets.FindAsync(id);

            if (ticket == null) return false;

            _db.Tickets.Remove(ticket);
            await _db.SaveChangesAsync();

            return true;
        }

    }
}
