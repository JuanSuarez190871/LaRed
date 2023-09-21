using LaRed.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppContext = LaRed.DataAccess.Data.AppContext;
namespace LaRed.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly AppContext _context;
        public AdminController(AppContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: api/Estados
        [HttpGet("Estados")]
        public async Task<ActionResult<IEnumerable<Estados>>> GetEstados()
        {
            try
            {
                return await _context.Estados.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Estados/5
        [HttpGet("Estados/{id}")]
        public async Task<ActionResult<Estados>> GetEstado(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }
            return estado;
        }
        // PUT: api/Estados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpEstados/{id}")]
        public async Task<IActionResult> PutEstados(int id, Estados estado)
        {
            if (id != estado.ID)
            {
                return BadRequest();
            }
            _context.Entry(estado).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        // POST: api/Estados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Estados")]

        public async Task<ActionResult<Activos>> PostActivos(Estados estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetActivos", new { id = estado.ID }, estado);
        }
        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        [ActionName("DelEstado")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }
            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool EstadoExists(int id)
        {
            return _context.Estados.Any(e => e.ID == id);
        }
    }
}
