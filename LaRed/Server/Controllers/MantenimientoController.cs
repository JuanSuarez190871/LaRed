using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppContext = LaRed.DataAccess.Data.AppContext;

namespace LaRed.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly AppContext _context;
    }
}
