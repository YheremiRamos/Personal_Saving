using Microsoft.AspNetCore.Mvc;
using Proyecto.Presentacion.Models;
using System.Diagnostics;

namespace Proyecto.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult listado()
        {
            return View();
        }
    }
}