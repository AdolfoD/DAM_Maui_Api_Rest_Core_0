using CapaEntidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models;
using System.Text.Json;


namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        /// //////////////////////////////////
        //Metodo controlador ListarPersona GET sin filtro
        /// //////////////////////////////////

        [HttpGet]

        public List<PersonaClS> listarPersona()
        {
            List<PersonaClS> lista = new List<PersonaClS>();

            try
            {
                using (DbAba245BdveterinariaContext bd = new DbAba245BdveterinariaContext())
                {
                    lista = (from persona in bd.Personas
                             where persona.Bhabilitado == 1
                             select new PersonaClS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombrecompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToString("yyyy-MM-dd")

                             }
                         ).ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {
                return lista;
            }
        }


        /// //////////////////////////////////
        //LISTAR PERSONA POR NOMBRE COMPLETO
        /// //////////////////////////////////


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
            catch (Exception ex)
            {
                return lista;
            }
        }


        /// //////////////////////////////////
        //RECUPERAR PERSONA
        /// //////////////////////////////////
        /// 

        [HttpGet("recuperarpersona/{id}")]

        public PersonaClS resuperarPersona(int id)
        {
            PersonaClS oPersonaCLS = new PersonaClS();

            try
            {
                using (DbAba245BdveterinariaContext bd = new DbAba245BdveterinariaContext())
                {
                    oPersonaCLS = (from persona in bd.Personas
                             where persona.Bhabilitado == 1 && persona.Iidpersona == id
                             select new PersonaClS
                             {
                                 iidpersona = persona.Iidpersona,
                                 nombre = persona.Nombre,
                                 appaterno = persona.Appaterno,
                                 apmaterno = persona.Apmaterno,
                                 correo = persona.Correo,
                                 fechanacimiento = (DateTime)persona.Fechanacimiento,
                                 fechanacimientocadena = persona.Fechanacimiento == null ? "" :
                                 persona.Fechanacimiento.Value.ToString("yyyy-MM-dd"),
                                 iidsexo = (int)persona.Iidsexo

                             }
                         ).First();
                }
                return oPersonaCLS;
            }
            catch (Exception ex)
            {
                return oPersonaCLS;
            }
        }
    }
    
}
   
