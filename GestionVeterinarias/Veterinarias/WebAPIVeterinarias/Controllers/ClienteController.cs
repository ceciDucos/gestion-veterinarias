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
    public class ClienteController : ApiController
    {
        private FachadaWeb fachadaWeb = FachadaWeb.GetInstance();

        // GET api/cliente/{id}
        public IHttpActionResult GetCliente(int id)
        {
            List<VOCliente> vocliente = new List<VOCliente>();
            VOCliente pepe = fachadaWeb.GetCliente(id);
            vocliente.Add(pepe);

            var cliente = vocliente.FirstOrDefault((p) => p.Cedula == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // Post api/cliente/
        public IHttpActionResult PostCliente(VOCliente vocliente)
        {            
            fachadaWeb.CrearCliente(vocliente);
            return Ok();
        }
    }
}
