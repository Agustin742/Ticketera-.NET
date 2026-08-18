using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Dtos;

public record CrearTicketDto(
    [Required][MaxLength(120)] string Titulo,
    string? Descripcion,
    [Required] int UsuarioId
);

public record ActualizarTicketDto(
    [Required][MaxLength(120)] string Titulo,
    string? Descripcion,
    [Required] EstadoTicket Estado
);

public record TicketDto(
    int Id,
    string Titulo,
    string? Descripcion,
    EstadoTicket Estado,
    DateTime CreadoEn,
    string NombreUsuario
);