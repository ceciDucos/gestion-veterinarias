using LogicaVeterinarias.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace LogicaVeterinarias.Controller
{
    class FachadaWin : System.Web.Services.WebService
    {
        [WebMethod]
        public void CrearVeterianaria(VOVeterinaria voveterinaria)
        {
        }

        [WebMethod]
        public void EditarVeterianaria(VOVeterinaria voveterinaria)
        {
        }

        [WebMethod]
        public void EliminarVeterianaria(int num)
        {
        }

        [WebMethod]
        public void CrearVeterianario(VOVeterinario voveterinario)
        {
        }

        [WebMethod]
        public void  EditarVeterianario(VOVeterinario voveterinario)
        {
        }

        [WebMethod]
        public void  EliminarVeterianario(long cedula)
        {
        }

        [WebMethod]
        public void  CrearCliente(VOCliente vocliente)
        {
        }

        [WebMethod]
        public void  EditarCliente(VOCliente vocliente)
        {
        }

        [WebMethod]
        public void  EliminarCliente(long cedula)
        {
        }

        [WebMethod]
        public void  CrearMascota(VOMascota vomascota)
        {
        }

        [WebMethod]
        public void  EditarMascota(VOMascota vomascota)
        {
        }

        [WebMethod]
        public void   EliminarMascota(int num)
        {
        }

        [WebMethod]
        public void  CrearCarne(VOCarnetInscripcion vocarnet)
        {
        }

        [WebMethod]
        public void  EditarCarne(VOCarnetInscripcion vocarnet)
        {
        }

        [WebMethod]
        public void  CrearConsulta(VOConsulta voconsulta)
        {
        }

        [WebMethod]
        public void  EditarConsulta(VOConsulta voconsulta)
        {
        }

        [WebMethod]
        public void  EliminarConsulta(int num)
        {
        }
    }
}
