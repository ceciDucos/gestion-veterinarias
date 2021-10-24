using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.Classes
{
    class CarnetInscripcion
    {
        private int numero; 

        public int Numero { get { return numero; } }
        public DateTime Expedido { get; set; }
        public byte[] Foto { get; set; }

        public CarnetInscripcion(int num, DateTime date, byte[] photo)
        {
            numero = num;
            Expedido = date;
            Foto = photo;
        }
    }
}
