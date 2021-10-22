using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.Classes
{
    abstract class Persona
    {
        public string Nombre { get; set; }
        public long Cedula { get; set; }
        public string Telefono { get; set; }

        public Persona() { }

        public Persona(string nombre, long cedula, string telefono) 
        {
            this.Nombre = nombre;
            this.Cedula = cedula;
            this.Telefono = telefono;
        }
    }
}
