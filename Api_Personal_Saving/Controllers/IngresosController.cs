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


    }
}

