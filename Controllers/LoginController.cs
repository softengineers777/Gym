using System;
using Microsoft.AspNetCore.Mvc;
using GuayabitosMvc.Services;

namespace GuayabitosMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _authService;

        public LoginController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string nombreUsuario, string contraseña)
        {
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                 ViewBag.Error = "Usuario  y Contraseña son Obligatorios";
                 return View();
            }
            var 
            return View();
        }



    }
}