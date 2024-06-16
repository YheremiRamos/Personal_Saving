using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto.Presentacion.Models;

namespace Proyecto.Presentacion.Controllers
{
    public class IngresoController : Controller
    {
        //Cadena conexion hacia el servicio
        Uri baseAddress = new Uri("https://localhost:7035/api");

        private readonly HttpClient _httpClient;

        public IngresoController()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult listadoIngresos()
        {
            List<IngresoModel> aIngresos = new List<IngresoModel>();
            HttpResponseMessage response =
                _httpClient.GetAsync(_httpClient.BaseAddress + "/Ingresos/listadoIngresos").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                aIngresos = JsonConvert.DeserializeObject<List<IngresoModel>>(data);
            }
            return View(aIngresos);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
