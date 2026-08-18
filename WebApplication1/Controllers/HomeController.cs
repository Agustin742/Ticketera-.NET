using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketService _service;
        public HomeController(ITicketService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index() => View(await _service.ObtenerTodosAsync());
    }
}
