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

        public EgresosO buscarEgresos(int id)
        {
            throw new NotImplementedException();
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
       public string nuevoEgreso(EgresosO objE)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_EGRESO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_egreso", objE.id_egreso);
                cmd.Parameters.AddWithValue("@id_usuario", objE.id_usuario);
                cmd.Parameters.AddWithValue("@id_transaccion", objE.id_transaccion);
                cmd.Parameters.AddWithValue("@fecha", objE.fecha);
                cmd.Parameters.AddWithValue("@monto", objE.monto);
                cmd.Parameters.AddWithValue("@descripcion", objE.descripcion);

                int n = cmd.ExecuteNonQuery();
                mensaje = n.ToString() + " Egreso registrado correctamente..!!";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar..!! " + ex.Message;
            }
            cn.Close();
            return mensaje;
        }
        //-----------ACTUALIZAR
         public string modificaEgreso(EgresosO objE)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_MERGE_EGRESO", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_egreso", objE.id_egreso);
                    cmd.Parameters.AddWithValue("@id_usuario", objE.id_usuario);
                    cmd.Parameters.AddWithValue("@id_transaccion", objE.id_transaccion);
                    cmd.Parameters.AddWithValue("@fecha", objE.fecha);
                    cmd.Parameters.AddWithValue("@monto", objE.monto);
                    cmd.Parameters.AddWithValue("@descripcion", objE.descripcion);

                    int n = cmd.ExecuteNonQuery();
                    mensaje = n.ToString() + " Egreso actualizado correctamente..!!";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al actualizar..!! " + ex.Message;
                }
                cn.Close();
            }
            return mensaje;
        }

    }
}
