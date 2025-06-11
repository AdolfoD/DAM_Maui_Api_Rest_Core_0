using CapaEntidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models;


namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet("{nombrecompleto}")]

        public List<PersonaClS> listarPersona(string nombrecompleto)
        {
            List<PersonaClS> lista = new List<PersonaClS>();

            try
            {
                using (DbAba245BdveterinariaContext bd = new DbAba245BdveterinariaContext())
                {
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             && (persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno).Contains(nombrecompleto)
                             select new PersonaClS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombrecompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToShortDateString()

                             }
                         ).ToList();
                }
                return lista;
            }
            catch(Exception ex)
            {
                return lista;
            }
        }
    }
}
