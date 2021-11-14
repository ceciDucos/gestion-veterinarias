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
        public string Pass { get; set; }
        public bool Activo { get; set; }
        public Dictionary<int, Mascota> DiccionarioMascotas { get; }

        public Cliente()
        {

        }

        public Cliente(long ci, string nombre, string tel, int idVeterinaria, string dir, string mail, string pass, bool activo) : base(ci, nombre, tel, idVeterinaria)
        {
            this.Direccion = dir;
            this.Correo = mail;
            this.Pass = pass;
            this.Activo = activo;
            this.DiccionarioMascotas = new Dictionary<int, Mascota>();
        }
    }
}
