using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.Classes
{
    class Cliente : Persona
    {
        string direccion { get; set; }
        string correo { get; set; }
        string contraseña { get; set; }
        bool activo { get; set; }
        //DiccionarioMascotas <Mascotas>

        public Cliente()
        {

        }

        public Cliente(string dir, string mail, string pass, bool active) : base(name,ci,tel)
        {
            direccion = dir;
            correo = mail;
            correo = mail;
            contraseña = pass;
            activo = active;
            //DiccionarioMascotas <Mascotas>
        }
    }
}
