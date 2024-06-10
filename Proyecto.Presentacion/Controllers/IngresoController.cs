using Microsoft.AspNetCore.Mvc;
using Proyecto.Presentacion.Models;

namespace Proyecto.Presentacion.Controllers
{
    public class IngresoController : Controller
    {
        
        public IActionResult listadoIngresos() { 
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
