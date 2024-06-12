namespace BACK_Api_Personal_Saving.Models
{
    public class EgresosO
    {
        public int id_egreso { get; set; }
        public int id_usuario { get; set; }
        public int id_transaccion { get; set; }
        public DateTime fecha { get; set; }
        public double monto { get; set; }
        public string? descripcion { get; set; }
    }
}
