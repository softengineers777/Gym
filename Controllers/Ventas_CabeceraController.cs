using System;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class Cabecera_VentaController : Controller
    {
        public readonly GuayabitosDbContext _context;
        public readonly IConfiguration _configuration;
        public Cabecera_VentaController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cabecera_Ventas.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cabecera_Ventas == null)
            {
                return NotFound();
            }
            var cabecera_venta = await _context.Cabecera_Ventas
            .FirstOrDefaultAsync(ca => ca.IdVenta == id);
            if (cabecera_venta == null)
            {
                return NotFound();
            }
            return View(cabecera_venta);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(List<Cabecera_Ventas> cabecera_Ventas)
        {
            try
            {
                if (cabecera_Ventas == null)
                {
                    Console.WriteLine("Los datos  han cargado");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"{ex.StackTrace}");
                TempData["Error"] = $"Error: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,Codigo_Venta,IdEmpleado,IdCliente,Fecha_Venta,SubTotal,Impuesto,Total,forma_pago,estado")] Cabecera_Ventas cabecera_Ventas)
        {

            if (id != cabecera_Ventas.IdVenta)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cabecera_Ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CabeceraVentaExists(cabecera_Ventas.IdVenta))
                    {
                        return NotFound();
                    }
                }
            }
            return RedirectToAction(nameof(Index));

        }
        public bool CabeceraVentaExists(int id)
        {
            return _context.Cabecera_Ventas.Any(ca => ca.IdVenta == id);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cabecera_venta = await _context.Cabecera_Ventas
            .FirstOrDefaultAsync(ca => ca.IdVenta == id);
            if (cabecera_venta == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleteconfirmed(int id)
        {
            var cabecera_venta = await _context.Cabecera_Ventas.FirstAsync();
            if (cabecera_venta == null)
            {
                return NotFound();
            }
            _context.Cabecera_Ventas.Remove(cabecera_venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
