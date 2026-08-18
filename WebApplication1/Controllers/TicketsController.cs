using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ITicketService _service;
        public TicketsController(ITicketService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<TicketDto>>> ObtenerTodos() =>
            Ok(await _service.ObtenerTodosAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TicketDto>> ObtenerPorId(int id)
        {
            var ticket = await _service.ObtenerPorIdAsync(id);
            return ticket is null ? NotFound() : Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> Crear(CrearTicketDto dto)
        {
            var creado = await _service.CrearAsync(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, ActualizarTicketDto dto) => 
            await _service.ActualizarAsync(id, dto) ? NoContent() : NotFound();

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id) =>
            await _service.EliminarAsync(id) ? NoContent() : NotFound();

    }
}
