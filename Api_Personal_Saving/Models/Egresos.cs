namespace BACK_Api_Personal_Saving.Models
{
    public class Egresos
    {
        //Paso1: Crear entidades (listado)
        public DateTime fecha { get; set; }
        public double monto { get; set; }

        public string? descripcion { get; set; }
    }
}
