using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOVeterinario
    {
        public long Cedula { get; }
        public string Nombre { get; }
        public string Telefono { get; }
        public string Horario { get; }
        public VOVeterinario(long cedula, string nombre, string telefono, string horario)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Horario = horario;
        }

    }
}
