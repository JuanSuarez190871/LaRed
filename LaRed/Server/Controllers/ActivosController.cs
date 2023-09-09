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
            return await _context.Activos.ToListAsync();
        }
    }
}
