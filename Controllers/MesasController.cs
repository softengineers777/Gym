using System.Data;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class MesasController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public MesasController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mesas.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mesas == null)
            {
                return NotFound();
            }
            var mesas = await _context.Mesas
            .FirstOrDefaultAsync(m => m.IdMesa == id);
            if (mesas == null)
            {
                return NotFound();
            }
            return View(mesas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(List<Mesas> mesas)
        {
            try
            {
                if (mesas == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                Console.WriteLine($"Mesas no es  null, {mesas.Count}");
                for (int i = 0; i < mesas.Count; i++)
                {
                    var m = mesas[i];
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
            var mesas = await _context.Mesas.FindAsync(id);
            if (mesas == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMesa,NumeroMesa,Capacidad,Estado,Activo")] Mesas mesas)
        {
            if (id != mesas.IdMesa)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesasExists(mesas.IdMesa))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mesas);
        }
        public bool MesasExists(int id)
        {
            return _context.Mesas.Any(m => m.IdMesa == id);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mesas = await _context.Mesas
            .FirstOrDefaultAsync(m => m.IdMesa == id);
            if (mesas == null)
            {
                return NotFound();
            }
            return View(mesas);
        }
        [HttpGet, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesas = await _context.Mesas.FindAsync(id);
            if (mesas == null)
            {
                return NotFound();
            }
            _context.Mesas.Remove(mesas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}