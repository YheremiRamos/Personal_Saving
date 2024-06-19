using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Presentacion.Models
{
    public class IngresoModelO
    {
        [DisplayName("Código de ingreso")]
        public int id_ingreso { get; set; }

        [DisplayName("Código de usuario")]
        [Required(ErrorMessage = "Ingrese el código de usuario")]
        public int id_usuario { get; set; }

        [DisplayName("Código de transacción")]
        [Required(ErrorMessage = "Ingrese el código de transacción")]
        public int id_transaccion { get; set; }

        [DisplayName("Fecha")]
        [Required(ErrorMessage = "Ingrese la fecha")]
        public DateTime fecha { get; set; }

        [DisplayName("Monto")]
        [Required(ErrorMessage = "Ingrese el monto")]
        public double monto { get; set; }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Ingrese la descripción")]
        public string? descripcion { get; set; }

        [DisplayName("Estado")]
        public int estado { get; set; }
    }
}
