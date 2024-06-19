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


        //_------------------ LISTAR ------------
        public IEnumerable<IngresosO> listarIngresosO()
        {
            List<IngresosO> aIngresosO = new List<IngresosO>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_INGRESOS_ORIGINAL", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aIngresosO.Add(new IngresosO()
                {
                    id_ingreso = int.Parse(dr[0].ToString()),
                    id_usuario = int.Parse(dr[1].ToString()),
                    id_transaccion = int.Parse(dr[2].ToString()),
                    fecha = DateTime.Parse(dr[3].ToString()),
                    monto = Double.Parse(dr[4].ToString()),
                    descripcion = dr[5].ToString(),
                    estado = int.Parse(dr[6].ToString())
                });

            }
            cn.Close();
            return aIngresosO;

        }

        //------------------------- BUSCAR ------------------
        public IngresosO buscarIngreso(int id)
        {
            return listarIngresosO().FirstOrDefault(c => c.id_ingreso == id);
        }

        //_--------------------- LISTAR ---------
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
                    codigo = int.Parse(dr[0].ToString()),
                    fecha = DateTime.Parse(dr[1].ToString()),
                    monto = Double.Parse(dr[2].ToString()),
                    descripcion = dr[3].ToString()
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
            int transacIngreso = 1;
            int estado = 3;
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_INGRESO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ingreso", objI.id_ingreso);
                cmd.Parameters.AddWithValue("@id_usuario", objI.id_usuario);
                cmd.Parameters.AddWithValue("@id_transaccion", transacIngreso);
                cmd.Parameters.AddWithValue("@fecha", objI.fecha);
                cmd.Parameters.AddWithValue("@monto", objI.monto);
                cmd.Parameters.AddWithValue("@descripcion", objI.descripcion);
                cmd.Parameters.AddWithValue("@estado", estado);

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
            int estado = 3;
            int transacIngreso = 1;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_MERGE_INGRESO", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_ingreso", objI.id_ingreso);
                    cmd.Parameters.AddWithValue("@id_usuario", objI.id_usuario);
                    cmd.Parameters.AddWithValue("@id_transaccion", transacIngreso);
                    cmd.Parameters.AddWithValue("@fecha", objI.fecha);
                    cmd.Parameters.AddWithValue("@monto", objI.monto);
                    cmd.Parameters.AddWithValue("@descripcion", objI.descripcion);
                    cmd.Parameters.AddWithValue("@estado", estado);

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

        public string eliminaIngreso(int id)
        {
            string mensajeEliminar = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINA_INGRESO", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_ingreso", id);
                    cmd.ExecuteNonQuery();
                    mensajeEliminar = " Ingreso eliminado correctamente..!!";
                }
                catch (Exception ex)
                {
                    mensajeEliminar = "Error al eliminar..!! " + ex.Message;
                }
                cn.Close();
            }
            return mensajeEliminar;
        }
    }
}
