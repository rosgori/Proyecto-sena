using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
