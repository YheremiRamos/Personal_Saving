using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Presentacion.Models
{
    public class IngresoModel
    {
        [DisplayName("Fecha")]
        //[Required(ErrorMessage = "Ingrese la fecha")]
        public DateTime fecha { get; set; }

        [DisplayName("Monto")]
        //[Required(ErrorMessage = "Ingrese el monto")]
        public double monto { get; set; }

        [DisplayName("Descripción")]
        //[Required(ErrorMessage = "Ingrese la descripción")]
        public string? descripcion { get; set; }
    }
}
