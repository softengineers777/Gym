using System.Data;
using System.Threading.Tasks;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public EmpleadosController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleados.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }
            var empleados = await _context.Empleados
            .FirstOrDefaultAsync(e => e.IdEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,Codigo,IdRol,puesto,Usuario_Login,Contraseña_hash,telefono,email,fecha_contratacion,salario")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(empleados);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,Codigo,IdRol,puesto,Usuario_Login,Contraseña_hash,telefono,email,fecha_contratacion,salario")] Empleados empleados)
        {
            if (id != empleados.IdEmpleado)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                    return (RedirectToAction("Edit", new { id = empleados.IdEmpleado }));

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.IdEmpleado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empleados);
        }
        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
        [HttpGet]
        public async Task<IActionResult>Delete (int? id)
        {
            if (id== null)
            {
                return NotFound();
            }
            var empleados = await _context.Empleados
            .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var  empleados = await _context.Empleados.FindAsync(id);
            if(empleados == null)
            {
                return NotFound();
            }
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}