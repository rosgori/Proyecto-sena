using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_sena.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Proyecto_sena.Models.DAOS;

namespace Proyecto_sena.Controllers
{
    public class SesionController : Controller
    {
        private readonly ILogger<SesionController> _logger;

        private proyecto_innubeContext base_datos = new proyecto_innubeContext();

        public SesionController(ILogger<SesionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ingresar(string correo, string contraseña)
        {

            var solicitudes = new List<Claim>();
            // Para el cliente natural
            
            var usuarioLogueado1 = ClienteDAO.ExisteUsuario(correo, contraseña);

            if (usuarioLogueado1 != null)
            {
                
                solicitudes.Add(new Claim("correo", correo));
                solicitudes.Add(new Claim(ClaimTypes.Email, correo));
                solicitudes.Add(new Claim(ClaimTypes.Name, correo));
                // solicitudes.Add(new Claim(ClaimTypes.Role, usuarioLogueado.Rol));
                var solicitud_identidad = new ClaimsIdentity(solicitudes, CookieAuthenticationDefaults.AuthenticationScheme);
                var solicitud_principal = new ClaimsPrincipal(solicitud_identidad);
                await HttpContext.SignInAsync(solicitud_principal);
                return RedirectToAction("Index", "Tablero");
            }

            // Para cliente compañía

            var usuarioLogueado2 = ClienteCompañiaDAO.ExisteUsuario(correo, contraseña);

            if (usuarioLogueado2 != null)
            {
                solicitudes.Add(new Claim("correo", correo));
                solicitudes.Add(new Claim(ClaimTypes.Email, correo));
                solicitudes.Add(new Claim(ClaimTypes.Name, correo));
                // solicitudes.Add(new Claim(ClaimTypes.Role, usuarioLogueado.Rol));
                var solicitud_identidad = new ClaimsIdentity(solicitudes, CookieAuthenticationDefaults.AuthenticationScheme);
                var solicitud_principal = new ClaimsPrincipal(solicitud_identidad);
                await HttpContext.SignInAsync(solicitud_principal);
                return RedirectToAction("Index", "TableroCM");
            }

            // Para la compañía ofertante

            var usuarioLogueado3 = CompañiumDAO.ExisteUsuario(correo, contraseña);

            if (usuarioLogueado3 != null)
            {
                solicitudes.Add(new Claim("correo", correo));
                solicitudes.Add(new Claim(ClaimTypes.Email, correo));
                solicitudes.Add(new Claim(ClaimTypes.Name, correo));
                // solicitudes.Add(new Claim(ClaimTypes.Role, usuarioLogueado.Rol));
                var solicitud_identidad = new ClaimsIdentity(solicitudes, CookieAuthenticationDefaults.AuthenticationScheme);
                var solicitud_principal = new ClaimsPrincipal(solicitud_identidad);
                await HttpContext.SignInAsync(solicitud_principal);
                return RedirectToAction("Index", "TableroC");
            }

            TempData["Error"] = "El usuario o la contraseña no son válidos.";
            return View("Index");


        }

        [Authorize]
        public async Task<IActionResult> SalirSesion()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
