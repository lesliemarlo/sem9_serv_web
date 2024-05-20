using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Proyecto.Presentacion.Models;
using System.Text;

namespace Proyecto.Presentacion.Controllers
{
    public class VendedorController : Controller
    {
        //cADENA CONEXION HACIA EL SERVICIO
       // Uri :clase para recursos

        Uri baseAddress = new Uri("https://localhost:7220/api");
        private readonly HttpClient _httpClient;

        public VendedorController() { 
        _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        //dis
        public List<Distrito> aDistritos()
        {
            List<Distrito> aDistritos = new List<Distrito>();
            HttpResponseMessage response =
            _httpClient.GetAsync(_httpClient.BaseAddress + "/Vendedor/listadoDistritos").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            aDistritos = JsonConvert.DeserializeObject<List<Distrito>>(data);
            return aDistritos;
        }



        //--
        [HttpGet]
        public IActionResult listadoVendedores() { 
        List<Vendedor> aVendedores= new List<Vendedor>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Vendedor/listadoVendedores").Result;
            if (response.IsSuccessStatusCode)
            { 
                var data = response.Content.ReadAsStringAsync().Result;
                aVendedores = JsonConvert.DeserializeObject<List<Vendedor>>(data);
            }
            return View(aVendedores);
        }
        //-- NUEVO
        [HttpGet]
        public IActionResult nuevoVendedor()
        {
            ViewBag.distrito = new SelectList(aDistritos(), "ide_dis", "nom_dis");
            return View(new VendedorO());
        }

        [HttpPost]
        public async Task<IActionResult> nuevoVendedor(VendedorO objC)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.distrito = new SelectList(aDistritos(), "ide_dis", "nom_dis");
                return View(objC);
            }
            var json = JsonConvert.SerializeObject(objC);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseC = await
            _httpClient.PostAsync("/api/Vendedor/nuevoVendedor", content);
            if (responseC.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Vendedor registrado correctamente..!!!";
            }
            ViewBag.distrito = new SelectList(aDistritos(), "ide_dis", "nom_dis");
            return View(objC);
        }


        //--
        public IActionResult Index()
        {
            return View();
        }
    }
}
