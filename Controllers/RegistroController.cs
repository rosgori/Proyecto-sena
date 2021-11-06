using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Proyecto_sena.Models;
using Proyecto_sena.Models.DAOS;

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
            var base_datos = new proyecto_innubeContext();

            // Para conseguir la lista de ciudades
            List<SelectListItem> lista_ciudad_seleccion = new();

            var lista_ciudad = base_datos.CiudadCompañia.ToList();

            foreach (var temp in lista_ciudad)
            {
                lista_ciudad_seleccion.Add(new SelectListItem { Value = temp.IdCiudad.ToString(), Text = temp.NombreCiudad });
            }

            // Para conseguir la lista de departamentos
            List<SelectListItem> lista_departamento_seleccion = new();

            var lista_departamento = base_datos.DepartamentoCompañia.ToList();

            foreach (var temp2 in lista_departamento)
            {
                lista_departamento_seleccion.Add(new SelectListItem { Value = temp2.IdDepartamento.ToString(), Text = temp2.NombreDepartamento });
            }

            ViewBag.lista_departamento = lista_departamento_seleccion;
            ViewBag.lista_ciudad = lista_ciudad_seleccion;

            return View();
        }

        public IActionResult RegEmpresaOfertante()
        {
            var base_datos = new proyecto_innubeContext();

            // Para conseguir la lista de ciudades
            List<SelectListItem> lista_ciudad_seleccion = new();

            var lista_ciudad = base_datos.CiudadCompañia.ToList();

            foreach (var temp in lista_ciudad)
            {
                lista_ciudad_seleccion.Add(new SelectListItem { Value = temp.IdCiudad.ToString(), Text = temp.NombreCiudad });
            }

            // Para conseguir la lista de departamentos
            List<SelectListItem> lista_departamento_seleccion = new();

            var lista_departamento = base_datos.DepartamentoCompañia.ToList();

            foreach (var temp2 in lista_departamento)
            {
                lista_departamento_seleccion.Add(new SelectListItem { Value = temp2.IdDepartamento.ToString(), Text = temp2.NombreDepartamento });
            }

            ViewBag.lista_departamento = lista_departamento_seleccion;
            ViewBag.lista_ciudad = lista_ciudad_seleccion;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCliente(IFormCollection formCollection)
        {
            string nombre = formCollection["nombre"];
            string apellido = formCollection["apellido"];
            string correo = formCollection["correo"];
            string contraseña = formCollection["contraseña"];

            Cliente clie = new Cliente();
            clie.IdCliente = ClienteDAO.CrearId();
            clie.NombreCliente = nombre;
            clie.ApellidoCliente = apellido;
            clie.CorreoElectronicoCliente = correo;

            string salt = ContraseñaClienteDAO.RandomString(10);
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var parte_encriptada = ContraseñaClienteDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);

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

            // var lista_cliente_general = base_datos.ClienteGenerals.ToList();
            ClienteGeneral cliente_gen = new ClienteGeneral(clie.IdCliente, true, false);
            base_datos.ClienteGenerals.Add(cliente_gen);

            base_datos.SaveChanges();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCompañiaCliente(IFormCollection formCollection)
        {

            string nombre = formCollection["NombreCompañia"];
            string telefono = formCollection["TelefonoCompañia"];
            string correo = formCollection["CorreoElectronicoCompañia"];
            string direccion = formCollection["DireccionCompañia"];
            string nit_compañia = formCollection["NitCompañia"];
            string id_ciudad = formCollection["IdCiudad"];
            string id_departamento = formCollection["IdDepartamento"];
            string contraseña = formCollection["contraseña"];

            ClienteCompañium clie = new ClienteCompañium();
            clie.IdClienteCompañia = ClienteCompañiaDAO.CrearId();
            clie.NombreCompañia = nombre;
            clie.TelefonoCompañia = telefono;
            clie.CorreoElectronicoCompañia = correo;
            clie.DireccionCompañia = direccion;
            clie.NitCompañia = nit_compañia;
            clie.IdCiudad = UInt16.Parse(id_ciudad);
            clie.IdDepartamento = UInt16.Parse(id_departamento);

            string salt = ContraseñaClienteCompañiumDAO.RandomString(10);
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var parte_encriptada = ContraseñaClienteCompañiumDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);

            var base_datos = new proyecto_innubeContext();

            ContraseñaClienteCompañium pass = new ContraseñaClienteCompañium();
            pass.ParteEncriptada = Convert.ToBase64String(parte_encriptada);
            pass.Salt = salt;
            base_datos.ContraseñaClienteCompañia.Add(pass);
            base_datos.SaveChanges();

            var lista_pass = base_datos.ContraseñaClienteCompañia.ToList();
            var obj = lista_pass.Find(u => u.ParteEncriptada == pass.ParteEncriptada);

            clie.IdContraseñaCompañia = obj.IdContraseñaCompañia;

            base_datos.ClienteCompañia.Add(clie);

            // var lista_cliente_general = base_datos.ClienteGenerals.ToList();
            ClienteGeneral cliente_gen = new ClienteGeneral(clie.IdClienteCompañia, false, true);
            base_datos.ClienteGenerals.Add(cliente_gen);

            base_datos.SaveChanges();

            return View("CrearCliente");
        }

        public IActionResult CrearCompañiaOfertante(IFormCollection formCollection)
        {

            string nombre = formCollection["NombreCompañia"];
            string telefono = formCollection["TelefonoCompañia"];
            string correo = formCollection["CorreoElectronicoCompañia"];
            string direccion = formCollection["DireccionCompañia"];
            string nit_compañia = formCollection["NitCompañia"];
            string id_ciudad = formCollection["IdCiudad"];
            string id_departamento = formCollection["IdDepartamento"];
            string contraseña = formCollection["contraseña"];

            Compañium clie = new Compañium();
            clie.IdCompañia = clie.CrearId();
            clie.NombreCompañia = nombre;
            clie.TelefonoCompañia = telefono;
            clie.CorreoElectronicoCompañia = correo;
            clie.DireccionCompañia = direccion;
            clie.NitCompañia = nit_compañia;
            clie.IdCiudad = UInt16.Parse(id_ciudad);
            clie.IdDepartamento = UInt16.Parse(id_departamento);

            string salt = ContraseñaClienteCompañiumDAO.RandomString(10);
            byte[] bytes_contraseña = Encoding.UTF8.GetBytes(contraseña);
            byte[] bytes_salt = Encoding.UTF8.GetBytes(salt);

            var parte_encriptada = ContraseñaClienteCompañiumDAO.GenerateSaltedHash(bytes_contraseña, bytes_salt);

            var base_datos = new proyecto_innubeContext();

            ContraseñaCompañium pass = new ContraseñaCompañium();
            pass.ParteEncriptada = Convert.ToBase64String(parte_encriptada);
            pass.Salt = salt;
            base_datos.ContraseñaCompañia.Add(pass);
            base_datos.SaveChanges();

            var lista_pass = base_datos.ContraseñaCompañia.ToList();
            var obj = lista_pass.Find(u => u.ParteEncriptada == pass.ParteEncriptada);

            clie.IdContraseñaCompañia = obj.IdContraseñaCompañia;

            base_datos.Compañia.Add(clie);

            // var lista_cliente_general = base_datos.ClienteGenerals.ToList();
            ClienteGeneral cliente_gen = new ClienteGeneral(clie.IdCompañia, false, true);
            base_datos.ClienteGenerals.Add(cliente_gen);

            base_datos.SaveChanges();

            return View("CrearCliente");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
