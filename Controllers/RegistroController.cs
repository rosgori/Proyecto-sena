using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_sena.Models;

namespace Proyecto_sena.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ILogger<RegistroController> _logger;

        public RegistroController(ILogger<RegistroController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegCliente()
        {
            return View();
        }

        public IActionResult RegEmpresa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(IFormCollection formCollection)
        {
            string nombre = formCollection["nombre"];
            string apellido = formCollection["apellido"];
            string correo = formCollection["correo"];
            string contraseña = formCollection["contraseña"];

            Cliente clie = new Cliente();
            clie.IdCliente = clie.CrearId();
            clie.NombreCliente = nombre;
            clie.ApellidoCliente = apellido;
            clie.CorreoElectronicoCliente = correo;

            string salt = ContraseñaCliente.RandomString(10);
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var parte_encriptada = ContraseñaCliente.GenerateSaltedHash(bytes_contraseña, bytes_salt);

            var base_datos = new proyecto_innubeContext();

            ContraseñaCliente pass = new ContraseñaCliente();
            pass.ParteEncriptada = Convert.ToBase64String(parte_encriptada);
            pass.Salt = salt;
            base_datos.ContraseñaClientes.Add(pass);
            base_datos.SaveChanges();

            var lista_pass = base_datos.ContraseñaClientes.ToList();
            var obj = lista_pass.Find(u => u.ParteEncriptada == pass.ParteEncriptada);

            clie.IdContraseñaCliente = obj.IdContraseñaCliente;

            base_datos.Clientes.Add(clie);
            base_datos.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
