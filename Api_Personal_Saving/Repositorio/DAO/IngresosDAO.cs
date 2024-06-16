using BACK_Api_Personal_Saving.Models;
using BACK_Api_Personal_Saving.Repositorio.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
        //-------------------------
        public IngresosO buscarIngreso(int id)
        {
            throw new NotImplementedException();
        }
        //_------------------------------
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
                aIngresos.Add(new Ingresos()
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

      

        //--------NUEVO INGRESO
        public string nuevoIngreso(IngresosO objI)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_INGRESO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ingreso", objI.id_ingreso);
                cmd.Parameters.AddWithValue("@id_usuario", objI.id_usuario);
                cmd.Parameters.AddWithValue("@id_transaccion", objI.id_transaccion);
                cmd.Parameters.AddWithValue("@fecha", objI.fecha);
                cmd.Parameters.AddWithValue("@monto", objI.monto);
                cmd.Parameters.AddWithValue("@descripcion", objI.descripcion);

                int n = cmd.ExecuteNonQuery();
                mensaje = n.ToString() + " Ingreso registrado correctamente..!!";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar..!! " + ex.Message;
            }
            cn.Close();
            return mensaje;

        }

        //------------------ACTUALIZAR
        public string modificaIngreso(IngresosO objI)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_MERGE_INGRESO", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_ingreso", objI.id_ingreso);
                    cmd.Parameters.AddWithValue("@id_usuario", objI.id_usuario);
                    cmd.Parameters.AddWithValue("@id_transaccion", objI.id_transaccion);
                    cmd.Parameters.AddWithValue("@fecha", objI.fecha);
                    cmd.Parameters.AddWithValue("@monto", objI.monto);
                    cmd.Parameters.AddWithValue("@descripcion", objI.descripcion);

                    int n = cmd.ExecuteNonQuery();
                    mensaje = n.ToString() + " Ingreso actualizado correctamente..!!";
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
