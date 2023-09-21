using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaRed.DataAccess.Data;
using System;
using AppContext = LaRed.DataAccess.Data.AppContext;
using LaRed.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LaRed.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivosController : ControllerBase
    {
        private readonly AppContext _context;
        public ActivosController(AppContext context) {

            _context = context;
        }
        // GET: api/Activos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activos>>> GetActivos()
        {
            try {
                return await _context.Activos.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Activos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activos>> GetActivos(int id)
        {
            var activos = await _context.Activos.FindAsync(id);
            if (activos == null)
            {
                return NotFound();
            }
            return activos;
        }
        // PUT: api/Activos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivos(int id, Activos activo)
        {
            if (id != activo.ID)
            {
                return BadRequest();
            }
            _context.Entry(activo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivoExists(id))
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
        // POST: api/Activos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Activos>> PostActivos(Activos activo)
        {
            _context.Activos.Add(activo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetActivos", new { id = activo.ID }, activo);
        }
        // DELETE: api/Activos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivo(int id)
        {
            var activo = await _context.Activos.FindAsync(id);
            if (activo == null)
            {
                return NotFound();
            }
            _context.Activos.Remove(activo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ActivoExists(int id)
        {
            return _context.Activos.Any(e => e.ID == id);
        }
    }
}
