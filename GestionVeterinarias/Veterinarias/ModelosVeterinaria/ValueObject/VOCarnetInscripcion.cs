using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOCarnetInscripcion
    {
        private int numero;

        public int Numero { get { return numero; } }
        public DateTime Expedido { get; }
        public byte[] Foto { get; }

        public VOCarnetInscripcion() { }

        public VOCarnetInscripcion(int numero, DateTime expedido, byte[] foto)
        {
            this.numero = numero;
            this.Expedido = expedido;
            this.Foto = foto;
        }

        public VOCarnetInscripcion(DateTime expedido, byte[] foto)
        {
            this.Expedido = expedido;
            this.Foto = foto;
        }

        public VOCarnetInscripcion(byte[] foto)
        {
            this.Foto = foto;
        }
    }
}