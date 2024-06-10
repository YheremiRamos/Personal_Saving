using Proyecto.Presentacion.Models;

namespace Proyecto.Presentacion.Repositorio.Interfaces
{
    public interface IIngreso
    {
        //Método para listar los ingresos
        IEnumerable<IngresoModel> listadoIngresos();
    }
}
