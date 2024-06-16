using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Proyecto.Presentacion.Models;

namespace FRONT_web_personal_saving.Controllers
{
    public class TransaccionController : Controller
    {

        //Cadena conexion hacia el servicio
        Uri baseAddress = new Uri("https://localhost:7035/api");

        private readonly HttpClient _httpClient;

        public TransaccionController()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult listadoTransacciones()
        {
            List<TransaccionModel> aTransacciones = new List<TransaccionModel>();
            HttpResponseMessage response =
                _httpClient.GetAsync(_httpClient.BaseAddress + "/Activos/listarActivos").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                aTransacciones = JsonConvert.DeserializeObject<List<TransaccionModel>>(data);
            }
            return View(aTransacciones);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
