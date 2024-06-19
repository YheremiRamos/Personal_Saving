using BACK_Api_Personal_Saving.Models;
using BACK_Api_Personal_Saving.Repositorio.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BACK_Api_Personal_Saving.Repositorio.DAO
{
    public class ActivosDAO : IActivos
    {
        //CADENA

        private readonly string? cadena;
        public ActivosDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }

        //-------------------------- MÉTODOS ----------------

        //LISTADO---------------
        public IEnumerable<Activos> listarActivos()
        {
            List<Activos> aActivos = new List<Activos>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ACTIVOS", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aActivos.Add(new Activos()
                {
                    fecha = DateTime.Parse(dr[0].ToString()),
                    monto = Double.Parse(dr[1].ToString()),
                    nombre = dr[2].ToString()
                });
            }
            cn.Close();
            return aActivos;
        }
    }
}
