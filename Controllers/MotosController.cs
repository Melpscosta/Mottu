using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mottu.Data;

namespace Mottu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly MotoDbContext _context;

        public MotosController(MotoDbContext context)
        {
            _context = context;
        }

        // GET: api/motos
        [HttpGet]
        public async Task<IActionResult> GetMotos()
        {
            var motos = await _context.Motos.ToListAsync();
            return Ok(motos);
        }
    }
}
