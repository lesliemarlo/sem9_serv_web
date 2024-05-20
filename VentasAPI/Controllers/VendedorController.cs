using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using VentasAPI.Models;
using VentasAPI.Repositorio.DAO;

namespace VentasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        [HttpGet("listadoVendedores")]
        public async Task<ActionResult<List<Vendedor>>> listadoVendedor()
        {
            var lista = await Task.Run(() => new VendedorDAO().listadoVendedor());
            return Ok(lista);
        }

        //listado dis
        [HttpGet("listadoDistritos")]
        public async Task<ActionResult<List<Distrito>>> listadoDistritos()
        {
            var lista = await Task.Run(() =>
            new DistritoDAO().listadoDistritos());
            return Ok(lista);
        }
        //--nuevo

        [HttpPost("nuevoVendedor")]
        public async Task<ActionResult<string>> nuevoVendedor(VendedorO objC)
        {
            var mensaje = await Task.Run(() =>
            new VendedorDAO().nuevoVendedor(objC));
            return Ok(mensaje);
        }
    }
}
