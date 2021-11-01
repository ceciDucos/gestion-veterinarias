using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.Classes
{
    public class Cliente : Persona
    {
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public Dictionary<int, Mascota> DiccionarioMascotas { get; }

        public Cliente()
        {

        }

        public Cliente(string nombre, long ci, string tel, string dir, string mail, string pass, bool activo) : base(nombre, ci, tel)
        {
            this.Direccion = dir;
            this.Correo = mail;
            this.Clave = pass;
            this.Activo = activo;
            this.DiccionarioMascotas = new Dictionary<int, Mascota>();
        }
    }
}
