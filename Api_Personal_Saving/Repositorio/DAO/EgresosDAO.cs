using BACK_Api_Personal_Saving.Models;
using BACK_Api_Personal_Saving.Repositorio.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BACK_Api_Personal_Saving.Repositorio.DAO
{
    //Paso3: creacion del dao(listado)
    public class EgresosDAO : IEgresos
    {
        //CADENA
       
        private readonly string? cadena;
        public EgresosDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }


        //-- 
        //--------------------------METODOS----------------

        //LISTADO---------------
        public IEnumerable<Egresos> listarEgresos()
        {
           List<Egresos> aEgresos = new List<Egresos>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_EGRESO", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aEgresos.Add(new Egresos
                {
                    fecha = DateTime.Parse(dr[0].ToString()),
                    monto = Double.Parse(dr[1].ToString()),
                    descripcion = dr[2].ToString()
                }) ;
            }
            cn.Close();
            return aEgresos;
            
        }

        //NUEVO EGRESO------------
    }
}
