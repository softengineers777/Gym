using System;
using System.Runtime.CompilerServices;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GuayabitosMvcController.Controllers
{
    public class Detalle_VentaController : Controller
    {
        public readonly GuayabitosDbContext _context;
        public readonly IConfiguration _configuration;

        public Detalle_VentaController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Detalle_Venta.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalle_Venta == null)
            {
                return NotFound();
            }
            var detalle_venta = await _context.Detalle_Venta
            .FirstOrDefaultAsync(d => d.IdDetalleV == id);
            if (detalle_venta == null)
            {
                return NotFound();
            }
            return View(detalle_venta);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(List<Detalle_Venta> detalle_Ventas)
        {
            try
            {
                if (detalle_Ventas == null)
                {
                    Console.WriteLine($"Los datos HAn sido cargados");
                    return RedirectToAction(nameof(Index));
                }
                // var detalle_ventaValidos = detalle_Ventas.Where(d=>!string.IsNullOrEmpty(p.))
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
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleV,IdVenta,IdProducto,Cantidad,precio_unitario,subTotal")] Detalle_Venta detalle_Venta)
        {
            if (id != detalle_Venta.IdDetalleV)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVentaExists(detalle_Venta.IdDetalleV))
                    {
                        return NotFound();
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }
        public bool DetalleVentaExists(int id)
        {
            return _context.Detalle_Venta.Any(d => d.IdDetalleV == id);
        }
        [HttpGet]
        public async Task<IActionResult>Deleted(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var detalle_venta = await _context.Detalle_Venta
            .FirstOrDefaultAsync (d=> d.IdDetalleV == id);
            if(detalle_venta == null)
            {
                return NotFound();
            }
            return View(detalle_venta);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var detalle_venta = await _context.Detalle_Venta.FirstAsync();
            if(detalle_venta == null)
            {
                return NotFound();
            }
            _context.Detalle_Venta.Remove(detalle_venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}