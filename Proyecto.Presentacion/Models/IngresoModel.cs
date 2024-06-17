using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Presentacion.Models
{
    public class IngresoModel
    {
        [DisplayName("Código")]
        public int codigo { get; set; }

        [DisplayName("Fecha de registro")]
        public DateTime fecha { get; set; }

        [DisplayName("Monto ingresado")]
        public double monto { get; set; }

        [DisplayName("Descripción del ingreso")]
        public string? descripcion { get; set; }
    }
}
