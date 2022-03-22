using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_sena.Models;
using Proyecto_sena.Models.DAOS;

namespace Proyecto_sena.Controllers
{
    public class TableroCMController : Controller
    {
        private proyecto_innubeContext base_datos = new proyecto_innubeContext();
        private readonly ILogger<TableroCMController> _logger;

        public TableroCMController(ILogger<TableroCMController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult MostrarDatos()
        {
            var correo = User.Identity.Name;
            var compañia = base_datos.ClienteCompañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo);

            ViewBag.compañia = compañia;
            return View();
        }

        [Authorize]
        public IActionResult Editar()
        {
            var correo = User.Identity.Name;
            var compañia = base_datos.ClienteCompañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo);

            ViewBag.compañia = compañia;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditarCompañia(IFormCollection formCollection)
        {
            string nombre = formCollection["nombre"];
            string telefono = formCollection["telefono"];
            string correo = formCollection["correo"];
            string direccion = formCollection["direccion"];
            string nit_compañia = formCollection["nit_compañia"];

            var correo_original = User.Identity.Name;
            var compañia = base_datos.Compañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo_original);

            if (!nombre.Equals(""))
            {
                compañia.NombreCompañia = nombre;
            }

            if (!telefono.Equals(""))
            {
                compañia.TelefonoCompañia = telefono;
            }

            if (!correo.Equals(""))
            {
                compañia.CorreoElectronicoCompañia = correo;
            }

            if (!direccion.Equals(""))
            {
                compañia.DireccionCompañia = direccion;
            }

            if (!nit_compañia.Equals(""))
            {
                compañia.NitCompañia = nit_compañia;
            }

            base_datos.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Contrasena()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditarContraseña(IFormCollection formCollection)
        {
            string contraseña = formCollection["contraseña"];
            
            var correo_original = User.Identity.Name;
            var persona = base_datos.ClienteCompañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo_original);

            var contraseña_datos = base_datos.ContraseñaClienteCompañia.FirstOrDefault(u => u.IdContraseñaCompañia == persona.IdContraseñaCompañia);

            string salt = ContraseñaClienteCompañiumDAO.RandomString(10);
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var parte_encriptada = ContraseñaClienteCompañiumDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);

            contraseña_datos.ParteEncriptada = Convert.ToBase64String(parte_encriptada);
            contraseña_datos.Salt = salt;
            base_datos.SaveChanges();

            return RedirectToAction("MostrarDatos");
        }
    }
}