using BACK_Api_Personal_Saving.Models;

namespace BACK_Api_Personal_Saving.Repositorio.Interfaces
{
    public interface IEgresos
        //paso2: crear interface (listado)
    {
        IEnumerable<Egresos> listarEgresos();

       /*
        IEnumerable<EgresosO> listadoEgresosO();

        //METODOS
        EgresosO buscarEgresos(int id);
        string nuevoEgreso(EgresosO objE);

        //metodo para actualizar pendiente
        //string modificaPaciente(Paciente objP);*/
    }
}
