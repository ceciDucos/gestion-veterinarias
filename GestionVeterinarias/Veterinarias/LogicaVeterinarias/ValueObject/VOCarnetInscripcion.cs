using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOCarnetInscripcion
    {
        public bool Expedido { get; }
        public byte[] foto { get; }



        public VOCarnetInscripcion(bool Expedido, byte[] Foto)
        {
            this.Expedido = Expedido;
            this.Foto = Foto;

        }

    }
}