using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuayabitosMvc.Models;

namespace GuayabitosMvc.Controllers
{
    public class MovimientoInventarioController : Controller
    {
        public readonly GuayabitosDbContext _context;
        public readonly IConfiguration _configuration;

        public MovimientoInventarioController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration =configuration;
        }
        public async Task <IActionResult>Index()
        {
            return View (await _context.MovimientoInventario.ToListAsync());
        }
        
    }
}
