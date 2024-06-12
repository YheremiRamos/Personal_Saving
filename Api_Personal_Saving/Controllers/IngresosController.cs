using BACK_Api_Personal_Saving.Models;
using BACK_Api_Personal_Saving.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BACK_Api_Personal_Saving.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        [HttpGet("listadoIngresos")]
        public async Task<ActionResult<List<Ingresos>>> listarIngresos()
        {
            var lista = await Task.Run(() => new IngresosDAO().listarIngresos());
            return Ok(lista);
        }

        //paso4: controller (registro)
       [HttpPost("nuevoIngreso")]
        public async Task<ActionResult<string>> nuevoIngreso(IngresosO objI)
        {
            var mensaje = await Task.Run(() =>
            new IngresosDAO().nuevoIngreso(objI));
            return Ok(mensaje);
        }

        //paso4: controller (actualizacion)
        [HttpPut("modificaIngreso")]
        public async Task<ActionResult<string>> modificaIngreso(IngresosO objI)
        {
            var mensaje = await Task.Run(() =>
            new IngresosDAO().modificaIngreso(objI));
            return Ok(mensaje);
        }


    }
}

