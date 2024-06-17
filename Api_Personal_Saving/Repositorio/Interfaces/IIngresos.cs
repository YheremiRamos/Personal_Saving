using BACK_Api_Personal_Saving.Models;

namespace BACK_Api_Personal_Saving.Repositorio.Interfaces
{
    public interface IIngresos
    {
        IEnumerable<Ingresos> listarIngresos();
        IEnumerable<IngresosO> listarIngresosO();
        IngresosO buscarIngreso(int id);
        string nuevoIngreso(IngresosO objI);
        //metodo para actualizar 
        string modificaIngreso(IngresosO objI);
        string eliminaIngreso(IngresosO objI);


    }
}
