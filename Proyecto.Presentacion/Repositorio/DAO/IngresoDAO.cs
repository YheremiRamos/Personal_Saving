using Proyecto.Presentacion.Models;
using Proyecto.Presentacion.Repositorio;
using Proyecto.Presentacion.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Proyecto.Presentacion.Repositorio.DAO
{
    public class IngresoDAO : IIngreso
    {

        public readonly IConfiguration Configuration;

        public IngresoDAO(IConfiguration iConfig)
        {
            Configuration = iConfig;
        }

        public IEnumerable<IngresoModel> listadoIngresos()
        {
            List<IngresoModel> aIngresos = new List<IngresoModel>();
            SqlConnection cn = new SqlConnection(Configuration["ConnectionStrings:cn"]);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_INGRESO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

            }
            cn.Close();
            return aIngresos;
        }
    }
}
