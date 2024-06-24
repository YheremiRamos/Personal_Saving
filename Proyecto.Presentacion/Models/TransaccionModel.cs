using System.ComponentModel;

namespace Proyecto.Presentacion.Models
{
    public class TransaccionModel
    {
        [DisplayName("Saldo según usuario")]
        public double saldo_actual { get; set; }

        [DisplayName("Fecha de registro")]
        public DateTime fecha { get; set; }


        [DisplayName("Monto registrado")]
        public double monto { get; set; }


        [DisplayName("Tipo de transacción")]
        public string? nombre { get; set; }
    }
}
