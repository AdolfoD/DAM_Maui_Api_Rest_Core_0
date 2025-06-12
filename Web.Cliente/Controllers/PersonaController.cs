using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using Web.Cliente.Clases;


namespace Web.Cliente.Controllers
{
    public class PersonaController : Controller
    {


        private string urlbase;
        private string cadena;
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonaController (IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            urlbase = configuration["baseurl"];
            cadena = "Hola";
            _httpClientFactory = httpClientFactory;

        }
        
        public IActionResult Index()
        {
            return View();
        }

        ///////////////////////////////////////////
        /// traer los datos o la data como string
        /// Metodo para listar personas sin filtro
        //////////////////////////////////////////
        
        public async Task<List<PersonaClS>> listarPersonas()
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);
            //string cadena = await cliente.GetStringAsync("api/Persona");
            //List<PersonaClS> lista = JsonSerializer.Deserialize<List<PersonaClS>>(cadena);
            //return lista;
            return await ClientHttp.GetAll<PersonaClS>(_httpClientFactory, urlbase, "/api/persona");
        }

        ///////////////////////////////////////////
        /// Metodo para listar personas con filtro
        //////////////////////////////////////////

        public async Task<List<PersonaClS>> FiltrarPersonas(string nombrecompleto)
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);
            //string cadena = await cliente.GetStringAsync("api/Persona/" + nombrecompleto);
            //List<PersonaClS> lista = JsonSerializer.Deserialize<List<PersonaClS>>(cadena);
            //return lista;
            return await ClientHttp.GetAll<PersonaClS>(_httpClientFactory, urlbase, "api/Persona/" + nombrecompleto);
        }

        ///////////////////////////////////////////
        /// Metodo para listar personas con filtro por ID
        //////////////////////////////////////////

        public async Task<PersonaClS> RecuperarPersona(int id)
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);
            //string cadena = await cliente.GetStringAsync("api/Persona/" + nombrecompleto);
            //List<PersonaClS> lista = JsonSerializer.Deserialize<List<PersonaClS>>(cadena);
            //return lista;
            return await ClientHttp.Get<PersonaClS>(_httpClientFactory, urlbase, "api/Persona/RecuperarPersona/" + id);
        }
    }
}
