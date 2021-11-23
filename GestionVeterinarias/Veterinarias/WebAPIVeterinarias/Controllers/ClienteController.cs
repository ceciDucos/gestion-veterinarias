using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using LogicaVeterinarias.Controller;
using ModelosVeterinarias.ExceptionClasses;
using ModelosVeterinarias.ValueObject;

namespace WebAPIVeterinarias.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {
        private FachadaWeb fachadaWeb = FachadaWeb.GetInstance();

        // GET api/cliente/
        [Authorize]
        public IHttpActionResult GetCliente()
        {
            try
            {
                var identity = Thread.CurrentPrincipal.Identity;
                List<VOCliente> vocliente = new List<VOCliente>();
                VOCliente pepe = fachadaWeb.GetCliente(Convert.ToInt32(identity.Name));
                vocliente.Add(pepe);

                var cliente = vocliente.FirstOrDefault((p) => p.Cedula == Convert.ToInt32(identity.Name));
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // Post api/cliente/
        public IHttpActionResult PostCliente(VOCliente vocliente)
        {
            try
            {
                fachadaWeb.CrearCliente(vocliente);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            var token = TokenGenerator.GenerateTokenJwt(Convert.ToString(vocliente.Cedula));
            return Ok(token);
        }

        // PUT api/cliente/
        [Route("api/cliente/password")]
        [Authorize]
        public IHttpActionResult PutChangePassword(VOPassword voPassword)
        {
            var identity = Thread.CurrentPrincipal.Identity;

            try
            {
                fachadaWeb.EditarPassword(identity.Name, voPassword);
            }
            catch (PersonaException)
            {
                return NotFound();
            }
            catch (PasswordException)
            {
                return BadRequest("La contraseña actual no coincide");
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        // PUT api/cliente/
        [Authorize]
        public IHttpActionResult PutCliente(VOCliente vocliente)
        {
            var identity = Thread.CurrentPrincipal.Identity;

            if (vocliente.Cedula == Convert.ToInt32(identity.Name))
            {
                try
                {
                    fachadaWeb.EditarCliente(vocliente);
                }
                catch (PersonaException)
                {
                    return NotFound();
                }
                catch (Exception)
                {
                    return InternalServerError();
                }
            } else
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
