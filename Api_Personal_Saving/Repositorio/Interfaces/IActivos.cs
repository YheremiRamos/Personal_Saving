using BACK_Api_Personal_Saving.Models;

namespace BACK_Api_Personal_Saving.Repositorio.Interfaces
{
    public interface IActivos
    {
        IEnumerable<Activos> listarActivos();
    }
}
