using System.Data;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace  GuayabitosMvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public ClientesController (GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        
        public  async Task <IActionResult> Index ()
        {
            return View (await _context.Clientes.ToListAsync());    
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Nombre,Telefono,email,fecha_registro")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }
    }
}