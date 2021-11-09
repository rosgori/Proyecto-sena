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
    public class TableroController : Controller
    {
        private proyecto_innubeContext base_datos = new proyecto_innubeContext();
        private readonly ILogger<TableroController> _logger;

        public TableroController(ILogger<TableroController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Buscar()
        {
            List<String> lista_datos = new List<string>();

            var oferta_servicios = base_datos.OfertaServicios.ToList();
            foreach (var ofer in oferta_servicios)
            {
                var servicio = base_datos.ServicioOfrecidos.FirstOrDefault(u => u.IdServicio == ofer.IdServicio);
                lista_datos.Add(servicio.NombreServicio);
                lista_datos.Add(servicio.PrecioServicio.ToString());
                var comp = base_datos.Compañia.FirstOrDefault(u => u.IdCompañia == ofer.IdCompañia);
                lista_datos.Add(comp.NombreCompañia);

            }

            ViewBag.longitud = lista_datos.Count();
            ViewBag.lista = lista_datos;
            return View();
        }

        [Authorize]
        public IActionResult MostrarDatos()
        {
            var correo = User.Identity.Name;
            var persona = base_datos.Clientes.FirstOrDefault(u => u.CorreoElectronicoCliente == correo);

            ViewBag.persona = persona;
            return View();
        }

        [Authorize]
        public IActionResult Editar()
        {
            var correo = User.Identity.Name;
            var persona = base_datos.Clientes.FirstOrDefault(u => u.CorreoElectronicoCliente == correo);

            ViewBag.persona = persona;
            return View();
        }

        [Authorize]
        public IActionResult EditarCliente(IFormCollection formCollection)
        {
            string nombre = formCollection["nombre"];
            string apellido = formCollection["apellido"];
            string correo = formCollection["correo"];

            var correo_original = User.Identity.Name;
            var persona = base_datos.Clientes.FirstOrDefault(u => u.CorreoElectronicoCliente == correo_original);

            if (!nombre.Equals(""))
            {
                persona.NombreCliente = nombre;
            }

            if (!apellido.Equals(""))
            {
                persona.ApellidoCliente = apellido;
            }

            if (!correo.Equals(""))
            {
                persona.CorreoElectronicoCliente = correo;
            }

            base_datos.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
