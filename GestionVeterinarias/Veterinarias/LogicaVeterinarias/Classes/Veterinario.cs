using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.Classes
{
    class Veterinario : Persona
    {
        public string Horario { get; set; }

        public Veterinario() { }

        public Veterinario(string nombre, long cedula, string telefono, string horario) : base(nombre, cedula, telefono)
        {
            this.Horario = horario;
        }
    }
}
