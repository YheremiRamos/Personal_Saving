using BACK_Api_Personal_Saving.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BACK_Api_Personal_Saving.Models;
using BACK_Api_Personal_Saving.Repositorio.DAO;

namespace BACK_Api_Personal_Saving.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgresosController : ControllerBase
    {
        //paso4: controller (listado)

        [HttpGet("listarEgresos")]
        public async Task<ActionResult<List<Egresos>>> listarEgresos()
        {
            var lista = await Task.Run(() => new EgresosDAO().listarEgresos());
            return Ok(lista);
        }
        //paso4: controller (registro)
        [HttpPost("nuevoEgreso")]
        public async Task<ActionResult<string>> nuevoEgreso(EgresosO objE)
        {
            var mensaje = await Task.Run(() =>
            new EgresosDAO().nuevoEgreso(objE));
            return Ok(mensaje);
        }
        //paso4: controller (actualizacion)
        [HttpPut("modificaEgreso")]
        public async Task<ActionResult<string>> modificaEgreso(EgresosO objE)
        {
            var mensaje = await Task.Run(() =>
            new EgresosDAO().modificaEgreso(objE));
            return Ok(mensaje);
        }
    }
}
