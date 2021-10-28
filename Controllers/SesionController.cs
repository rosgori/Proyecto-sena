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
            // lectura de base de datos
            // Ya se hace al principio de la clase

            bool existe = base_datos.Clientes.ToList().Exists(c => c.CorreoElectronicoCliente == correo);

            if (!existe)
            {
                return View("Index");
            }

            Cliente persona = base_datos.Clientes.FirstOrDefault(c => c.CorreoElectronicoCliente == correo);

            uint? id_contraseña = persona.IdContraseñaCliente;

            ContraseñaCliente contra = base_datos.ContraseñaClientes.Find(id_contraseña);

            var salt = contra.Salt;
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var contraseña_encriptada = ContraseñaCliente.GenerateSaltedHash(bytes_contraseña, bytes_salt);
            var contraseña_encriptada2 = Convert.ToBase64String(contraseña_encriptada);

            existe = base_datos.ContraseñaClientes.ToList().Exists(u => u.ParteEncriptada == contraseña_encriptada2);

            if (!existe)
            {
                return View("Index");
            }

            var usuarioLogueado = base_datos.ContraseñaClientes.FirstOrDefault(u => u.ParteEncriptada == contraseña_encriptada2);
            Console.WriteLine(usuarioLogueado);

            if (usuarioLogueado != null)
            {
                var solicitudes = new List<Claim>();
                solicitudes.Add(new Claim("correo", correo));
                solicitudes.Add(new Claim(ClaimTypes.Email, correo));
                solicitudes.Add(new Claim(ClaimTypes.Name, correo));
                // solicitudes.Add(new Claim(ClaimTypes.Role, usuarioLogueado.Rol));
                var solicitud_identidad = new ClaimsIdentity(solicitudes, CookieAuthenticationDefaults.AuthenticationScheme);
                var solicitud_principal = new ClaimsPrincipal(solicitud_identidad);
                await HttpContext.SignInAsync(solicitud_principal);
                return RedirectToAction("Index", "Tablero");
            }
            else
            {
                TempData["Error"] = "El usuario o contraseña no son válidos.";
                return View("Index");
            }

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
