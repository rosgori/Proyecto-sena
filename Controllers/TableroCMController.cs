using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        [Authorize]
        public IActionResult Buscar()
        {
            List<String> lista_datos = new List<string>();

            var oferta_servicios = base_datos.OfertaServicios.ToList();
            foreach (var ofer in oferta_servicios)
            {
                var servicio = base_datos.ServicioOfrecidos.FirstOrDefault(u => u.IdServicio == ofer.IdServicio);
                lista_datos.Add(servicio.IdServicio);
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
        public IActionResult CogerDatos([FromBody] JsonDocument values)
        {
            List<string> listas_ids = new List<string>();

            Console.WriteLine("Probando");
            JsonElement a = values.RootElement;
            JsonElement ids = a.GetProperty("ids");
            foreach (var c in ids.EnumerateArray())
            {
                if (c.TryGetProperty("id", out JsonElement valor_id))
                {
                    listas_ids.Add(valor_id.GetString());
                }
            }
            TempData["lista_ids"] = listas_ids;

            return RedirectToAction("MostrarServicios", new { ll = listas_ids });
        }

        [Authorize]
        [HttpGet]
        // public IActionResult MostrarServicios([FromBody] JsonDocument values)
        public IActionResult MostrarServicios(List<string> ll)
        {
            List<String> lista_datos = new List<string>();
            // var ids = CogerDatos(values);
            var ids = ll;

            IEnumerable<string> ids2 = ids as IEnumerable<string>;

            foreach (var item in ids)
            {
                var servicio = base_datos.ServicioOfrecidos.FirstOrDefault(u => u.IdServicio.Equals(item));
                lista_datos.Add(servicio.IdServicio);
                lista_datos.Add(servicio.NombreServicio);
                lista_datos.Add(servicio.PrecioServicio.ToString());
            }

            ViewBag.longitud = lista_datos.Count();
            ViewBag.lista = lista_datos;

            return View();
        }
    }
}