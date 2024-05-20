using VentasAPI.Models;

namespace VentasAPI.Repositorio.Interfaces
{
    public interface IVendedor
    {
        IEnumerable<Vendedor> listadoVendedor();
        IEnumerable<VendedorO> listadoVendedorO();

        //metodos
        VendedorO buscarVendedor(int id);
        string nuevoVendedor(VendedorO objV);
        string modificaVendedor(VendedorO objV); //son objteos locales (objV)
    }
}
