using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuayabitosMvc.Models;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GuayabitosMvc.Controllers
{
    public class ComprasController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public ComprasController(GuayabitosDbContext context, IConfiguration configuration)

        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compras.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }
            var compras = await _context.Compras
            .FirstOrDefaultAsync(c => c.IdCompras == id);
            if (compras == null)
            {
                return NotFound();
            }
            return View(compras);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompras,IdProveedor,fecha_compra,total,estado")] Compras compras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compras);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var compras = await _context.Compras.FindAsync(id);
            if (compras == null)
            {
                return NotFound();
            }
            return View(compras);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind("IdCompras,IdProveedor,fecha_compra,total,estado")]Compras compras)
        {
            if (id != compras.IdCompras)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compras);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!ComprasExists(compras.IdCompras))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                RedirectToAction(nameof(Index));
            }
            return View (compras);
            
        }
        public bool ComprasExists(int id)
        {
             return _context.Compras.Any(c => c.IdCompras == id);
        }
        [HttpGet, ActionName("Delete")]
        public  async Task <IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var compras = await _context.Compras
            .FirstOrDefaultAsync(c =>c.IdCompras == id);
            if(compras == null)
            {
                return NotFound();
            }
            return View(compras);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compras = await _context.Compras.FindAsync(id);
            if (compras == null)
            {
                 return NotFound(); 
            }
            _context.Compras.Remove(compras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






    }
}