using System.ComponentModel;

namespace Proyecto.Presentacion.Models
{
    public class TransaccionModel
    {
        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }


        [DisplayName("Monto")]
        public double monto { get; set; }


        [DisplayName("Tipo_transacción")]
        public string? tipoTransacdecion { get; set; }
    }
}
