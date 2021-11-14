using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOVeterinario
    {
        public long Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int IdVeterinaria { get; set; }
        public string Horario { get; set; }

        public VOVeterinario(){}

        public VOVeterinario(long cedula, string nombre, string telefono, int idVeterinaria, string horario)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.IdVeterinaria = idVeterinaria;
            this.Telefono = telefono;
            this.Horario = horario;
        }

        public override string ToString() {
            return String.Format("Cedula {0} - Nombre {1} - Teléfono {2} - Horario de atención {3}",
                         this.Cedula, this.Nombre, this.Telefono, this.Horario);
        }
    }
}
