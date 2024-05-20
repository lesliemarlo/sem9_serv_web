using VentasAPI.Models;

namespace VentasAPI.Repositorio.Interfaces
{
    public interface IDistrito
    {

        //Llenar el combo en la presentación
        IEnumerable<Distrito> listadoDistritos();

    }
}
