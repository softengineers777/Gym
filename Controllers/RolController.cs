using System;
using GuayabitosMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace GuayabitosMvc.Controllers
{
    public class RolController : Controller
    {
        public readonly GuayabitosDbContext _context;
        public readonly IConfiguration _configuration;

        public RolController(GuayabitosDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task <IActionResult>Index()
        {
            return View(await _context.Rol.ToListAsync());
        }
        public async Task<IActionResult>Details(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }
            var rol = await _context.Rol
            .FirstOrDefaultAsync (r=> r.IdRol == id);
            if(rol == null)
            {
                return NotFound();
            }
            return View (rol);
        }
        [HttpPost]
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create ([Bind("IdRol,Nombre,Descripcion,Nivel_Acceso")]Rol rol)
        {
            if(ModelState.IsValid)
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rol = await  _context.Rol.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View (rol);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult>Edit (int id,[Bind("IdRol,Nombre,Descripcion,Nivel_Acceso")]Rol rol)
        {
            if (id != rol.IdRol)
            {
                return NotFound();
            }   
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!RolExists(rol.IdRol))
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
            return View(rol);

        }
        public  bool RolExists(int? id)
        {
            return _context.Rol.Any(r => r.IdRol == id);
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int? id)
        {
            
        }


    }

}