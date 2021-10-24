using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOVeterinario
    {
        public long Cedula { get; }
        public String Nombre { get; }
        public String Telefono { get; }
        public String Horario { get; }

        public VOVeterinario(long Cedula, String Nombre, String Telefono, String Horario)
        {
            this.Cedula = Cedula;
            this.Nombre = Nombre;
            this.Telefono = Telefono;
            this.Horario = Horario;

        }

    }
}
