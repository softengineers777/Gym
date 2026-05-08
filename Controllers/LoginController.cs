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
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return RedirectToAction("Index","Home");
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
            var (exito, mensaje, usuario) = await _authService.LoginAsync(nombreUsuario, contraseña);
            if (exito)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = mensaje;
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            _authService.Logout();
            return RedirectToAction("Index", "Login");
        }



    }
}