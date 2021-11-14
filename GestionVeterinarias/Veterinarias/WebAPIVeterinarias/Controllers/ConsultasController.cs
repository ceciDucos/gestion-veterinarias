using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using LogicaVeterinarias.Controller;
using ModelosVeterinarias.ValueObject;

namespace WebAPIVeterinarias.Controllers
{
    public class ConsultasController : ApiController
    {
        private FachadaWeb fachadaWeb = FachadaWeb.GetInstance();

        // GET api/consultas/{id}
        public IEnumerable<VOConsulta> Get(int id)
        {
            return fachadaWeb.GetConsultas(id);
        }

        // PUT api/consultas/{id}
        public void SetCalificacion(int numero, int calificacion)
        {
            fachadaWeb.SetCalificacion(numero, calificacion);
        }
    }
}
