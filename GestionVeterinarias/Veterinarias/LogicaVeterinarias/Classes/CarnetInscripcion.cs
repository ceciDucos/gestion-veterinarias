using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.Classes
{
    class CarnetInscripcion
    {
        int Numero { get; }
        DateTime Expedido { get; set; }
        byte[] Foto { get; set; }

        public CarnetInscripcion(int num, DateTime date, byte[] photo)
        {
            Numero = num;
            Expedido = date;
            Foto = photo;
        }
    }
}
