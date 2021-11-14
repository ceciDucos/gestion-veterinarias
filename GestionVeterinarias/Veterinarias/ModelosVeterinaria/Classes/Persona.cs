using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.Classes
{
    public abstract class Persona
    {
        public long Cedula { get; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int IdVeterinaria { get; set; }

        public Persona() { }

        public Persona(long cedula, string nombre, string telefono, int idVeterinaria) 
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.IdVeterinaria = idVeterinaria;
        }
    }
}
