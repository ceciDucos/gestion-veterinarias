using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.Classes
{
    public class Veterinario : Persona
    {
        public string Horario { get; set; }

        public Veterinario() { }

        public Veterinario(long cedula, string nombre, string telefono, int idVeterinaria, string horario) : base(cedula, nombre, telefono, idVeterinaria)
        {
            Horario = horario;
        }
    }
}
