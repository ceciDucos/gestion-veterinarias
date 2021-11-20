using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using LogicaVeterinarias.Controller;
using ModelosVeterinarias.ValueObject;

namespace WebAPIVeterinarias.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ConsultasController : ApiController
    {
        private FachadaWeb fachadaWeb = FachadaWeb.GetInstance();

        // GET api/consultas/{id}
        public IEnumerable<VOConsulta> Get(int id)
        {
            return fachadaWeb.GetConsultas(id);
        }

        // PUT api/consultas/
        public IHttpActionResult Put(VOConsulta voconsulta)
        {
            fachadaWeb.SetCalificacion(voconsulta.Numero, voconsulta.Calificacion);
            return Ok();
        }
    }
}
