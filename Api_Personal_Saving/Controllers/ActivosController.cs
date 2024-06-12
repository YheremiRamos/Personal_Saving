using BACK_Api_Personal_Saving.Models;
using BACK_Api_Personal_Saving.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BACK_Api_Personal_Saving.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivosController : ControllerBase
    {
        //paso4: controller (listado)

        [HttpGet("listarActivos")]
        public async Task<ActionResult<List<Activos>>> listarActivos()
        {
            var lista = await Task.Run(() => new ActivosDAO().listarActivos());
            return Ok(lista);
        }
    }
}
