﻿using ModelosVeterinarias.ValueObject;
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
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceVeterinarias : System.Web.Services.WebService
    {

        [WebMethod]
        public void CrearVeterianaria(VOVeterinaria voveterinaria)
        {
            FachadaWin fachada = new FachadaWin();
            fachada.CrearVeterianaria(voveterinaria);
        }
    }
}
