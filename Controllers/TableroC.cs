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
    }
}