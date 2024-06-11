using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Proyecto.Presentacion.Models;

namespace Proyecto.Presentacion.Controllers
{
    public class EgresoController : Controller
    {


            //Definir la cadena de conexion 
            public readonly IConfiguration Configuration;

            public EgresoController(IConfiguration configuration)
            {
                this.Configuration = configuration;
            }


            public List<Egreso> aEgreso()
            {
                List<Egreso> aEgreso = new List<Egreso>();
                SqlConnection cn = new SqlConnection(Configuration["ConnectionStrings:cn"]);
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_EGRESO", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    aEgreso.Add(new Egreso()
                    {
                        id = int.Parse(dr[0].ToString()),
                        id_usuario = int.Parse(dr[1].ToString()),
                        id_transaccion = int.Parse(dr[2].ToString()),
                        fecha = DateTime.Parse(dr[3].ToString()),
                        monto = double.Parse(dr[4].ToString()),
                        descripcion = dr[5].ToString()

                    });
                }
                cn.Close();
                return aEgreso;
            }

            public IActionResult ListaEgreso()
            {
                return View(aEgreso());
            }

            public IActionResult Index()
        {
            return View();
        }
    }
}
