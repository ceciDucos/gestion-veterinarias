using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.Classes
{
    class Cliente : Persona
    {
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
        public Dictionary<Mascota> DiccionarioMascotas { get; }

        public Cliente()
        {

        }

        public Cliente(string dir, string mail, string pass, bool active) : base(name,ci,tel)
        {
            Direccion = dir;
            Correo = mail;
            Contraseña = pass;
            Activo = active;
            this.DiccionarioMascotas = new Dictionary<int, Mascota>();
        }
    }
}
