using BACK_Api_Personal_Saving.Models;

namespace BACK_Api_Personal_Saving.Repositorio.Interfaces
{
    public interface IIngresos
    {
        IEnumerable<Ingresos> listarIngresos();
        IngresosO buscarIngreso(int id);
        string nuevoIngreso(IngresosO objI);
        //metodo para actualizar 
        string modificaIngreso(IngresosO objI);


    }
}
