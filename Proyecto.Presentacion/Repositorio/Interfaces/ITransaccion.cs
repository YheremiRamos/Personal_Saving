using Proyecto.Presentacion.Models;

namespace Proyecto.Presentacion.Repositorio.Interfaces
{
    public interface ITransaccion
    {
        //Método para listar las transacciones (Ingresos - Egresos)
        IEnumerable<TransaccionModel> listadoTransacciones();
    }
}
