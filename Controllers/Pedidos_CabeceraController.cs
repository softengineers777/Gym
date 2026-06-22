using System.Data;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GuayabitosMvc.Controllers
{
    public class Pedidos_CabeceraController : Controller
    {
        private readonly GuayabitosDbContext _context;
        private readonly IConfiguration _configuration;

        public Pedidos_CabeceraController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedidos_Cabecera.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos_Cabecera == null)
            {
                return NotFound();
            }
            var pedidos_cabecera = await _context.Pedidos_Cabecera
            .FirstOrDefaultAsync(pc => pc.IdPedidos == id);
            if (pedidos_cabecera == null)
            {
                return NotFound();
            }
            return View(pedidos_cabecera);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //este  controlador  esta resumido  para que  se  pueda  hacer  la creacion  de multiples  registros  de  un  solo guardado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiple(List<Pedidos_Cabecera> pedidos_Cabeceras)
        {
            if (pedidos_Cabeceras == null)
            {
                Console.WriteLine("Si llego el contenido  Pedidos Cabecera");
                TempData["Error"] = "No se recibieron  datos del  formulario";
                return RedirectToAction(nameof(Index));
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
            var pedidos_Cabeceras = await _context.Pedidos_Cabecera.FirstAsync();
            if (pedidos_Cabeceras == null)
            {
                return NotFound();
            }
            return View(pedidos_Cabeceras);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, [Bind("IdPedidos,IdMesa,IdEmpleado,IdCliente,FechaPedido,Estado,Total,Observaciones,Activo")] Pedidos_Cabecera pedidos_Cabeceras)
        {
            if (id != pedidos_Cabeceras.IdPedidos)
            {
                return NotFound();
            }
            // var pedidos_Cabeceras = await _context.Pedidos_Cabecera.
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidos_Cabeceras);
                    await _context.SaveChangesAsync();

                }
                catch (DBConcurrencyException)
                {
                    if (!Pedidos_CabeceraExists(pedidos_Cabeceras.IdPedidos))
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
            return View(pedidos_Cabeceras);
        }
        public bool Pedidos_CabeceraExists(int? id)
        {
            return _context.Pedidos_Cabecera.Any(pd => pd.IdPedidos == id);
        }
        



    }
}