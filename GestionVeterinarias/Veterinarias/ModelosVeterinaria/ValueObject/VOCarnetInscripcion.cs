using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOCarnetInscripcion
    {
        public bool Expedido { get; }
        public byte[] Foto { get; }
        public VOCarnetInscripcion(bool expedido, byte[] foto)
        {
            this.Expedido = expedido;
            this.Foto = foto;
        }

    }
}