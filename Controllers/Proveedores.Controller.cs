using System.Data;
using System.Threading.Tasks;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public ProveedoresController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proveedores.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proveedores == null)
            {
                return NotFound();
            }
            var proveedores = await _context.Proveedores
            .FirstOrDefaultAsync(p => p.IdProveedor == id);
            if (proveedores == null)
            {
                return NotFound();
            }
            return View(proveedores);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMultiple(List<Proveedores> proveedores)
        {
            try
            {
                if (proveedores == null)
                {
                    Console.WriteLine($"Los proveedores si cargaron en la base de  datos");
                    TempData["Error"] = "No se  recibieron datos del Formulario";
                    return RedirectToAction(nameof(Index));
                }
                for (int i = 0; i < proveedores.Count; i++)
                {
                    var p = proveedores[i];
                }
                var proveedoresValidos = proveedores.Where(p => !String.IsNullOrEmpty(p.Nombre)).ToList();

                if (proveedoresValidos.Any())
                {
                    foreach (var proveedor in proveedoresValidos)
                    {
                        if (proveedor.FechaRegistro == default)
                        {
                            proveedor.FechaRegistro = DateTime.Now;
                        }
                        _context.Proveedores.Add(proveedor);
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    TempData["Error"] = "no se  recibieron Proveedores  validos ṕara  guardar";
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var proveedores = await _context.Proveedores.FindAsync(id);
            if (proveedores == null)
            {
                return NotFound();
            }
            return View(proveedores);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedor, Nombre, Apellido, telefono, direccion,FechaRegistro")] Proveedores proveedores)
        {
            if (id != proveedores.IdProveedor)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedoresExists(proveedores.IdProveedor))
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
            return View(proveedores);
        }
        public bool ProveedoresExists(int id)

        {
            return _context.Proveedores.Any(m => m.IdProveedor == id);
        }

        [HttpGet]
        public async Task<IActionResult>Delete(int? id)
        {
            if (id== null)
            {
                return NotFound();
            }
            var  proveedores = await _context.Proveedores
            .FirstOrDefaultAsync (m =>m.IdProveedor == id);
            if (proveedores == null)
            {
                return NotFound();
            }
            return View (proveedores);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteConfirmed (int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if(proveedor == null)
            {
                return NotFound();
            }
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}