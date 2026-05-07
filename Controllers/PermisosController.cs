using System.Data;
using System.Data.SqlClient;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class PermisosController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public PermisosController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null || _context.Permisos == null)
            {
                return NotFound();
            }
            var permisos = await _context.Permisos
            .FirstOrDefaultAsync(p => p.IdPermisos == id);
            if (permisos == null)
            {
                return NotFound();
            }
            return View(permisos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("IdPermisos,Nombre,Codigo,Descripcion")] Permisos permisos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}