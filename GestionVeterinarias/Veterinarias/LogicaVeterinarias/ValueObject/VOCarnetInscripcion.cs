using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOCarnetInscripcion
    {
        public int Numero { get;}
        public bool Expedido { get;}
        public byte[] foto { get; }

        

        public VOCarnetInscripcion(int Numero, bool Expedido, byte[] Foto)
        {
            this.Numero = Numero;
            this.Expedido = Expedido;
            this.Foto = Foto;
        
        }

    }
}
