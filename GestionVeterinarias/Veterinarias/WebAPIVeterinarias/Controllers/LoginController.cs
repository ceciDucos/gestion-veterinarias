using LogicaVeterinarias.Controller;
using ModelosVeterinaria.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPIVeterinarias.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {

        private FachadaWeb fachadaWeb = FachadaWeb.GetInstance();

        [HttpPost]
        public IHttpActionResult Authenticate(VOLogin login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            bool isCredentialValid = fachadaWeb.Login(login);
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
