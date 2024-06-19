
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Proyecto.Presentacion.Models;
using System.Text;

namespace Proyecto.Presentacion.Controllers
{
    public class IngresoController : Controller
    {
        //Cadena conexión hacia el servicio
        Uri baseAddress = new Uri("https://localhost:7035/api");

        private readonly HttpClient _httpClient;

        public IngresoController()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = baseAddress;
        }



        //Listado Ingresos
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
                @ViewBag.Ingresos = aIngresos;
                @ViewBag.primero = aIngresos.FirstOrDefault();
            }
            return View(aIngresos);
        }

        //Registro Ingresos
        [HttpGet]
        public IActionResult NuevoIngreso()
        {
            return View(new IngresoModelO());
        }
        [HttpPost]
        public async Task<IActionResult> NuevoIngreso(IngresoModelO objI)
        {
            if (!ModelState.IsValid)
            {
                return View(new IngresoModelO());
            }
            var json = JsonConvert.SerializeObject(objI);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseC = await
            _httpClient.PostAsync("api/Ingresos/nuevoIngreso", content);
            if (responseC.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Ingreso registrado correctamente..!!!";
            }
            //ViewBag.codigoI = json;
            return View(objI);
        }

        //Actualización de Ingresos
        [HttpGet]
        public async Task<IActionResult> ModificarIngreso(int id)
        {
            var response = await
            _httpClient.GetAsync(_httpClient.BaseAddress + "/Ingresos/buscarIngreso/" + id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var objI = JsonConvert.DeserializeObject<IngresoModelO>(content);
                return View(objI);
            }
            else
            {
                ViewBag.mensaje = "No hay ingreso!!!";
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ModificarIngreso(int id, IngresoModelO objI)
        {
            /*
             if (!ModelState.IsValid)
            {
                return View(new IngresoModelO());
            }
             */
            var json = JsonConvert.SerializeObject(objI);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/Ingresos/modificaIngreso?id={ id }", content);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Ingreso actualizado correctamente..!!!";
            }
            return View(objI);
        }


        //Eliminación de Ingresos
        [HttpDelete]
        public async Task<IActionResult> EliminarIngreso(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Ingresos/eliminaIngreso/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(responseData);

                if (result.success == true)
                {
                    ViewBag.mensaje = "Ingreso eliminado correctamente..!!!";
                    return RedirectToAction("listadoIngresos"); // Redirigir al listado después de la eliminación
                }
                else
                {
                    ViewBag.mensaje = "No se eliminó el ingreso: " + result.message;
                    return RedirectToAction("listadoIngresos");
                }
            }
            else
            {
                ViewBag.mensaje = "Error en la comunicación con el servidor.";
                return RedirectToAction("listadoIngresos");
            }
        }





        public IActionResult Index()
        {
            return View();
        }

        /*
         [HttpDelete]
        public async Task<IActionResult> EliminarIngreso(int id)
        {
             var response = await  _httpClient.DeleteAsync($"api/Ingresos/eliminarIngreso/{id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Ingreso eliminado correctamente..!!!";
                return RedirectToAction("listadoIngresos"); // Redirigir al listado después de la eliminación
            }
            else
            {
                ViewBag.mensaje = "No se eliminó el ingreso";
                return RedirectToAction("listadoIngresos");
            }
        }*/
    }
}
