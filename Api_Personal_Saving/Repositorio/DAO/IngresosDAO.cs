using BACK_Api_Personal_Saving.Models;
using BACK_Api_Personal_Saving.Repositorio.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BACK_Api_Personal_Saving.Repositorio.DAO
{
    public class IngresosDAO : IIngresos
    {

        //Definir la cadena de conexion
        private readonly string? cadena;
        public IngresosDAO()
        {

            cadena = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("cn");

        }

        public IEnumerable<Ingresos> listarIngresos()
        {
            List<Ingresos> aIngresos = new List<Ingresos>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_INGRESO", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aIngresos.Add(new Ingresos
                {   
                    fecha = DateTime.Parse(dr[0].ToString()),
                    monto = Double.Parse(dr[1].ToString()),
                    descripcion = dr[2].ToString()
                }
                );

            }
            cn.Close();
            return aIngresos;

        }
    }
}
