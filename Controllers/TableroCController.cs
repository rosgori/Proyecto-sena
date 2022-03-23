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
            var compañia = base_datos.Compañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo);

            ViewBag.compañia = compañia;
            return View();
        }

        [Authorize]
        public IActionResult Editar()
        {
            var correo = User.Identity.Name;
            var compañia = base_datos.Compañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo);

            ViewBag.compañia = compañia;
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
        public IActionResult ListarServicios()
        {
            var correo = User.Identity.Name;
            var compañia = base_datos.Compañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo);

            var servicios_id = base_datos.OfertaServicios.Where(el => el.IdCompañia == compañia.IdCompañia).ToList();

            List<String> lista_datos = new List<string>();

            foreach (var ele in servicios_id)
            {
                var servicio = base_datos.ServicioOfrecidos.FirstOrDefault(e => e.IdServicio == ele.IdServicio);

                lista_datos.Add(servicio.IdServicio);
                lista_datos.Add(servicio.NombreServicio);
                lista_datos.Add(servicio.PrecioServicio.ToString());
            }

            ViewBag.longitud = lista_datos.Count();
            ViewBag.lista = lista_datos;

            return View();
        }

        [Authorize]
        public IActionResult FormServicio()
        {
            return View();
        }

        [Authorize]
        public IActionResult AgregarServicio(IFormCollection formCollection)
        {
            string id_servicio = formCollection["id-servicio"];
            string nombre_servicio = formCollection["nombre_servicio"];
            string precio_servicio = formCollection["precio_servicio"];
            string descripcion_servicio = formCollection["descripcion-servicio"];

            if (id_servicio.Equals(""))
            {
                id_servicio = ServicioOfrecidoDAO.CrearId();
            }

            // Para quitar espacios en ambos lados de la cadena

            nombre_servicio = nombre_servicio.Trim();
            precio_servicio = precio_servicio.Trim();
            descripcion_servicio = descripcion_servicio.Trim();

            ServicioOfrecido servicio_ofrecido = new ServicioOfrecido();

            servicio_ofrecido.IdServicio = id_servicio;
            servicio_ofrecido.NombreServicio = nombre_servicio;
            servicio_ofrecido.PrecioServicio = UInt32.Parse(precio_servicio);
            servicio_ofrecido.Descripcion = descripcion_servicio;

            base_datos.ServicioOfrecidos.Add(servicio_ofrecido);

            var correo = User.Identity.Name;
            var compañia = base_datos.Compañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo);

            OfertaServicio servicio_ofertado = new OfertaServicio();

            servicio_ofertado.IdServicio = id_servicio;
            servicio_ofertado.IdCompañia = compañia.IdCompañia;

            base_datos.OfertaServicios.Add(servicio_ofertado);

            base_datos.SaveChanges();

            return RedirectToAction("ListarServicios");

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
            var persona = base_datos.Compañia.FirstOrDefault(u => u.CorreoElectronicoCompañia == correo_original);

            var contraseña_datos = base_datos.ContraseñaCompañia.FirstOrDefault(u => u.IdContraseñaCompañia == persona.IdContraseñaCompañia);

            string salt = ContraseñaCompañiumDAO.RandomString(10);
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var parte_encriptada = ContraseñaCompañiumDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);

            contraseña_datos.ParteEncriptada = Convert.ToBase64String(parte_encriptada);
            contraseña_datos.Salt = salt;
            base_datos.SaveChanges();

            return RedirectToAction("MostrarDatos");
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditarS(IFormCollection coleccion)
        {
            string id_producto = coleccion["id_producto"];
            var servicio_ofertado = base_datos.ServicioOfrecidos.FirstOrDefault(u => u.IdServicio == id_producto);

            ViewBag.servicio = servicio_ofertado;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditarServicio(IFormCollection coleccion)
        {
            string id_servicio = coleccion["id-servicio"];
            string nombre = coleccion["nombre_servicio"];
            string precio = coleccion["precio_servicio"];
            string descripcion = coleccion["descripcion-servicio"];

            var servicio_ofertado = base_datos.ServicioOfrecidos.FirstOrDefault(u => u.IdServicio == id_servicio);

            servicio_ofertado.NombreServicio = nombre.Trim();
            servicio_ofertado.PrecioServicio = Convert.ToUInt32(precio.Trim());
            servicio_ofertado.Descripcion = descripcion.Trim();

            base_datos.SaveChanges();

            return RedirectToAction("ListarServicios");
        }
    }
}