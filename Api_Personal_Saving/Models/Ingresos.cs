namespace BACK_Api_Personal_Saving.Models
{
    public class Ingresos
    {


        public int codigo { get; set; }
        public DateTime fecha { get; set; }
        public double monto { get; set; }

        public string? descripcion { get; set; }

    }
}
