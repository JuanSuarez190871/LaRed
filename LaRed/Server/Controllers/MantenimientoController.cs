using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppContext = LaRed.DataAccess.Data.AppContext;
using LaRed.Shared.Models;
using LaRed.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LaRed.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly AppContext _context;

        public MantenimientoController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Mantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> GetMantenimiento()
        {
            if (_context.Mantenimiento == null)
            {
                return NotFound();
            }
            return await _context.Mantenimiento.ToListAsync();
        }

        // GET: api/Mantenimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mantenimiento>> GetMantenimiento(int id)
        {
            if (_context.Mantenimiento == null)
            {
                return NotFound();
            }
            var mantenimiento = await _context.Mantenimiento.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound();
            }

            return mantenimiento;
        }

        // PUT: api/Mantenimiento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMantenimiento(int id, Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.ID)
            {
                return BadRequest();
            }

            _context.Entry(mantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MantenimientoExists(id))
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

        // POST: api/Mantenimiento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mantenimiento>> PostMantenimiento(Mantenimiento mantenimiento)
        {
            if (_context.Mantenimiento == null)
            {
                return Problem("Entity set 'AppDbContext.Mantenimiento'  is null.");
            }
            _context.Mantenimiento.Add(mantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMantenimiento", new { id = mantenimiento.ID }, mantenimiento);
        }

        // DELETE: api/Mantenimiento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento(int id)
        {
            if (_context.Mantenimiento == null)
            {
                return NotFound();
            }
            var mantenimiento = await _context.Mantenimiento.FindAsync(id);
            if (mantenimiento == null)
            {
                return NotFound();
            }

            _context.Mantenimiento.Remove(mantenimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MantenimientoExists(int id)
        {
            return (_context.Mantenimiento?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
