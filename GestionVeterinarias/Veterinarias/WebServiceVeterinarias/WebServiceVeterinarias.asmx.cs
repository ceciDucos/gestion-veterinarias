using ModelosVeterinarias.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LogicaVeterinarias.Controller;

namespace WebServiceVeterinarias
{
    /// <summary>
    /// Summary description for WebServiceVeterinarias
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebServiceVeterinarias : System.Web.Services.WebService
    {
        FachadaWin fachada = new FachadaWin();

        #region Métodos de Veterinaria
        [WebMethod(Description = "Servicio para crear una veterinaria nueva")]
        public void CrearVeterianaria(VOVeterinaria voveterinaria)
        {
            fachada.CrearVeterianaria(voveterinaria);
        }

        [WebMethod(Description = "Servicio para modificar una veterinaria existente")]
        public void EditarVeterinaria(VOVeterinaria voveterinaria)
        {
            fachada.EditarVeterianaria(voveterinaria);
        }

        [WebMethod(Description = "Servicio para eliminar una veterinaria existente")]
        public void EliminarVeterinaria(int numero)
        {
            fachada.EliminarVeterianaria(numero);
        }
        #endregion

        #region Métodos de Veterinario
        [WebMethod(Description = "Obtener los veterinarios existentes")]
        public List<VOVeterinario> ObtenerVeterinarios()
        {
            return fachada.ObtenerVeterinarios();
        }

        [WebMethod(Description = "Servicio para crear un veterinario nuevo")]
        public void CrearVeterianario(VOVeterinario voveterinario)
        {
            fachada.CrearVeterinario(voveterinario);
        }

        [WebMethod(Description = "Servicio para modificar una veterinario existente")]
        public void EditarVeterinario(VOVeterinario voveterinario)
        {
            fachada.EditarVeterinario(voveterinario);
        }

        [WebMethod(Description = "Servicio para eliminar una veterinario existente")]
        public void EliminarVeterinario(int numero)
        {
            fachada.EliminarVeterinario(numero);
        }

        [WebMethod(Description = "Obtener un veterinario existente")]
        public VOVeterinario ObtenerVeterinario(long cedula)
        {
            return fachada.ObtenerVeterinario(cedula);
        }
        #endregion

        #region Métodos de Cliente

        [WebMethod(Description = "Servicio para crear un cliente nuevo")]
        public void CrearCliente(VOCliente vocliente)
        {
            fachada.CrearCliente(vocliente);
        }

        [WebMethod(Description = "Servicio para modificar un cliente existente")]
        public void EditarCliente(VOCliente vocliente)
        {
            fachada.EditarCliente(vocliente);
        }

        [WebMethod(Description = "Servicio para eliminar un cliente existente")]
        public void EliminarCliente(int numero)
        {
            fachada.EliminarCliente(numero);
        }
        #endregion

        #region Métodos de Mascota

        [WebMethod(Description = "Servicio para crear una mascota nueva")]
        public void CrearMascota(VOMascota vomascota)
        {
            fachada.CrearMascota(vomascota);
        }

        [WebMethod(Description = "Servicio para modificar una mascota existente")]
        public void EditarMascota(VOMascota vomascota)
        {
            fachada.EditarMascota(vomascota);
        }

        [WebMethod(Description = "Servicio para eliminar una mascota existente")]
        public void EliminarMascota(int numero)
        {
            fachada.EliminarMascota(numero);
        }

        [WebMethod(Description = "Servicio para determinar si existe una mascota")]
        public void MemberMascota(int numero)
        {
            fachada.MemberMascota(numero);
        }
        #endregion

        #region Métodos de Carnet
        [WebMethod(Description = "Servicio para crear un carnet nuevo")]
        public void CrearCarnet(byte[] foto, int id)
        {
            fachada.CrearCarnet(foto, id);
        }

        [WebMethod(Description = "Servicio para modificar un carnet existente")]
        public void EditarCarnet(VOCarnetInscripcion vocarnet)
        {
            fachada.EditarCarnet(vocarnet);
        }
        #endregion

        #region Métodos de Consulta

        [WebMethod(Description = "Servicio para crear una consulta nueva")]
        public void CrearConsulta(VOConsulta voconsulta)
        {
            fachada.CrearConsulta(voconsulta);
        }

        [WebMethod(Description = "Servicio para modificar una consulta existente")]
        public void EditarConsulta(VOConsulta voconsulta)
        {
            fachada.EditarConsulta(voconsulta);
        }

        [WebMethod(Description = "Servicio para eliminar una consulta existente")]
        public void EliminarConsulta(int numero)
        {
            fachada.EliminarConsulta(numero);
        }
        #endregion
    }
}
