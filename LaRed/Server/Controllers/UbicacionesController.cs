using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using AppContext = LaRed.DataAccess.Data.AppContext;
using LaRed.Shared.Models;
using Microsoft.EntityFrameworkCore;
using LaRed.DataAccess.Data;

namespace LaRed.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UbicacionesController : ControllerBase
    {
        private readonly AppContext _context;



        public UbicacionesController(AppContext context)
        {
            _context = context;
        }



        // GET: api/Ubicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicaciones>>> GetUbicaciones()
        {
            if (_context.Ubicaciones == null)
            {
                return NotFound();
            }
            return await _context.Ubicaciones.ToListAsync();
        }



        // GET: api/Ubicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicaciones>> GetUbicacion(int id)
        {
            if (_context.Ubicaciones == null)
            {
                return NotFound();
            }
            var ubicacion = await _context.Ubicaciones.FindAsync(id);



            if (ubicacion == null)
            {
                return NotFound();
            }



            return ubicacion;
        }



        // PUT: api/Ubicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacion(int id, Ubicaciones ubicacion)
        {
            if (id != ubicacion.ID)
            {
                return BadRequest();
            }



            _context.Entry(ubicacion).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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



        // POST: api/Ubicaciones **
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ubicaciones>> PostUbicacion(Ubicaciones ubicacion)
        {
            if (_context.Ubicaciones == null)
            {
                return Problem("Entity set 'AppDbContext.Ubicaciones'  is null.");
            }
            _context.Ubicaciones.Add(ubicacion);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetUbicacion", new { id = ubicacion.ID }, ubicacion);
        }



        // DELETE: api/Ubicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacion(int id)
        {
            if (_context.Ubicaciones == null)
            {
                return NotFound();
            }
            var ubicacion = await _context.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }



            _context.Ubicaciones.Remove(ubicacion);
            await _context.SaveChangesAsync();



            return NoContent();
        }



        private bool UbicacionExists(int id)
        {
            return (_context.Ubicaciones?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
