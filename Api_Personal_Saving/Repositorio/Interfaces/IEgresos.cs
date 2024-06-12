using BACK_Api_Personal_Saving.Models;

namespace BACK_Api_Personal_Saving.Repositorio.Interfaces
{
    public interface IEgresos
        //paso2: crear interface (listado)
    {
        IEnumerable<Egresos> listarEgresos();

     

        //METODOS
        EgresosO buscarEgresos(int id);
        string nuevoEgreso(EgresosO objE);

        //metodo para actualizar 
        string modificaEgreso(EgresosO objE);
    }
}
