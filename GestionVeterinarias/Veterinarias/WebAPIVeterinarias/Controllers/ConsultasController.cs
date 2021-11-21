using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
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

        // GET api/consultas/
        public IEnumerable<VOConsulta> Get()
        {
            try
            {
                var identity = Thread.CurrentPrincipal.Identity;
                return fachadaWeb.GetConsultas(Convert.ToInt32(identity.Name));
            }
            catch (Exception)
            {
                return new List<VOConsulta>();
            }
        }

        // PUT api/consultas/
        [Authorize]
        public IHttpActionResult Put(VOConsulta voconsulta)
        {
            try
            {
                var identity = Thread.CurrentPrincipal.Identity;
                fachadaWeb.SetCalificacion(Convert.ToInt32(identity.Name), voconsulta.Numero, voconsulta.Calificacion);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
