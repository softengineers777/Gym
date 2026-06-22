using System.Data;
using System.Threading.Tasks;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class Pedidos_DetalleController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public Pedidos_DetalleController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedidos_Detalle.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos_Detalle == null)
            {
                return NotFound();
            }
            var pedidos_detalle = await _context.Pedidos_Detalle
            .FirstOrDefaultAsync(pd => pd.IdDetallePedido == id);
            if (pedidos_detalle == null)
            {
                return NotFound();
            }
            return View(pedidos_detalle);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // // public  async Task<IActionResult> CreateMultiple(List<Pedidos_Detalle>pedidos_detalle)
        // {
        //     try
        //     {
        //         if (pedidos_detalle == null)
        //         {
        //             return RedirectToAction(nameof(Index));
        //         }
        //         Console.WriteLine($"Pedido detall no es  null {pedidos_detalle.Count}");
        //         for (int i = 0; i <pedidos_detalle.Count; i++)
        //         {
        //             var pd= pedidos_detalle[i];
        //             // Console.WriteLine()
        //         }
        //         var 
        //     }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(List<Pedidos_Detalle> pedidos_detalle)
        {
            try
            {
                if (pedidos_detalle == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                Console.WriteLine($"Pedido detall no es  null {pedidos_detalle.Count}");
                for (int i = 0; i < pedidos_detalle.Count; i++)
                {
                    var pd = pedidos_detalle[i];
                    // Console.WriteLine()
                }
                // var pedidos_detalleValidos = pedidos_detalle.Where (c=> !String.IsNullOrEmpty(c.Nombre)).Tolist();
                // if(pedidos_detalleValidos.Any())
                // {
                //     foreach(pedidos_detalleValidos.)
                // }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                Console.WriteLine($"detalle:{ex.StackTrace}");
                TempData["Error"] = $"Error {ex.Message}";
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
            var pedidos_detalle = await _context.Pedidos_Detalle.FindAsync(id);
            if (pedidos_detalle == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetallePedido,IdPedido,IdProducto,Cantidad,PrecioUnitario,SubTotal,Observaciones,Estado")] Pedidos_Detalle pedidos_detalle)
        {
            if (id != pedidos_detalle.IdDetallePedido)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidos_detalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pedidos_DetalleExists(pedidos_detalle.IdDetallePedido))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(pedidos_detalle);
        }
        public bool Pedidos_DetalleExists(int? id)
        {
            return _context.Pedidos_Detalle.Any(pd => pd.IdDetallePedido == id);
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int id )
        {
            var  pedidos_detalle = await _context.Pedidos_Detalle.FindAsync(id);
            if (pedidos_detalle ==null)
            {
                return NotFound();
            }
            _context.Pedidos_Detalle.Remove(pedidos_detalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidos_detalle = await  _context.Pedidos_Detalle.FindAsync(id);
            if(pedidos_detalle == null)
            {
                return NotFound();
            }
            _context.Pedidos_Detalle.Remove(pedidos_detalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

