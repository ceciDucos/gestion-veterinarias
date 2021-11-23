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
    public class VeterinariaController : ApiController
    {
        private FachadaWeb fachadaWeb = FachadaWeb.GetInstance();

        // GET api/veterinaria
        public IEnumerable<VOVeterinaria> Get() 
        {
            return fachadaWeb.GetVeterinarias();
        }

        // GET api/veterinaria/{id}
        [Authorize]
        public IHttpActionResult GetVeterinaria(int id)
        {
            var vet = fachadaWeb.GetVeterinarias().FirstOrDefault((p) => p.Id == id); // LINQ
            if (vet == null)
            {
                return NotFound();
            }
            return Ok(vet);
        }        
    }
}
