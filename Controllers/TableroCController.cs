using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_sena.Models;

namespace Proyecto_sena.Controllers
{
    public class TableroCController : Controller
    {
        private proyecto_innubeContext base_datos = new proyecto_innubeContext();
        private readonly ILogger<TableroCController> _logger;

        public TableroCController(ILogger<TableroCController> logger)
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
            return View();
        }

        [Authorize]
        public IActionResult EditarCompañia(IFormCollection formCollection)
        {
            string nombre = formCollection["nombre"];
            string telefono = formCollection["telefono"];
            string correo = formCollection["correo"];
            string direccion = formCollection["direccion"];
            string nit_compañia = formCollection["nit_compañia"];

            var correo_original = User.Identity.Name;
            var compañia = base_datos.ClienteCompañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo_original);

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
    }
}