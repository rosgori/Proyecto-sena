using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Text;
using System.Text.Json;
// using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proyecto_sena.Models;
using Proyecto_sena.Models.DAOS;

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

        [Authorize(Roles="1")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="1")]
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

        [Authorize(Roles="1")]
        public IActionResult MostrarDatos()
        {
            var correo = User.Identity.Name;
            var persona = base_datos.Clientes.FirstOrDefault(u => u.CorreoElectronicoCliente == correo);

            ViewBag.persona = persona;
            return View();
        }

        [Authorize(Roles="1")]
        public IActionResult Editar()
        {
            var correo = User.Identity.Name;
            var persona = base_datos.Clientes.FirstOrDefault(u => u.CorreoElectronicoCliente == correo);

            ViewBag.persona = persona;
            return View();
        }

        [Authorize(Roles="1")]
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

        [Authorize(Roles="1")]
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

        [Authorize(Roles="1")]
        [HttpGet]
        // public IActionResult MostrarServicios([FromBody] JsonDocument values)
        public IActionResult MostrarServicios(List<string> ll)
        {
            List<String> lista_datos = new List<string>();
            List<String> lista_compañias = new List<string>();
            // var ids = CogerDatos(values);
            var ids = ll;

            IEnumerable<string> ids2 = ids as IEnumerable<string>;

            foreach (var item in ids)
            {
                var servicio = base_datos.ServicioOfrecidos.FirstOrDefault(u => u.IdServicio.Equals(item));
                var temp1 = base_datos.OfertaServicios.FirstOrDefault(u => u.IdServicio == servicio.IdServicio);
                var compañia = base_datos.Compañia.FirstOrDefault(u => u.IdCompañia == temp1.IdCompañia);
            
                lista_datos.Add(servicio.IdServicio);
                lista_datos.Add(servicio.NombreServicio);
                lista_datos.Add(servicio.PrecioServicio.ToString());
                lista_compañias.Add(compañia.NombreCompañia);
                lista_compañias.Add(compañia.CorreoElectronicoCompañia);
                lista_compañias.Add(compañia.TelefonoCompañia);
            }

            ViewBag.longitud = lista_datos.Count();
            ViewBag.lista = lista_datos;
            ViewBag.lista_compañias = lista_compañias;

            return View();
        }

        [Authorize(Roles="1")]
        public IActionResult Contrasena()
        {
            return View();
        }

        [Authorize(Roles="1")]
        [HttpPost]
        public IActionResult EditarContraseña(IFormCollection formCollection)
        {
            string contraseña = formCollection["contraseña"];
            
            var correo_original = User.Identity.Name;
            var persona = base_datos.Clientes.FirstOrDefault(u => u.CorreoElectronicoCliente == correo_original);

            var contraseña_datos = base_datos.ContraseñaClientes.FirstOrDefault(u => u.IdContraseñaCliente == persona.IdContraseñaCliente);

            string salt = ContraseñaClienteDAO.RandomString(10);
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var parte_encriptada = ContraseñaClienteDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);

            contraseña_datos.ParteEncriptada = Convert.ToBase64String(parte_encriptada);
            contraseña_datos.Salt = salt;
            base_datos.SaveChanges();

            return RedirectToAction("MostrarDatos");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
