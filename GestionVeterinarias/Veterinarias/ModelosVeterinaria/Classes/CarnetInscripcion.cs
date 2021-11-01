using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.Classes
{
    public class CarnetInscripcion
    {
        private int numero; 

        public int Numero { get { return numero; } }
        public DateTime Expedido { get; set; }
        public byte[] Foto { get; set; }

        public CarnetInscripcion(int num, DateTime fecha, byte[] foto)
        {
            this.numero = num;
            this.Expedido = fecha;
            this.Foto = foto;
        }
    }
}
