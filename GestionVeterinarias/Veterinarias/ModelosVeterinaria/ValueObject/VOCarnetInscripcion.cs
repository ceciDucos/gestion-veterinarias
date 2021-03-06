using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOCarnetInscripcion
    {

        public int Numero { get; set; }
        public DateTime Expedido { get; set; }
        public byte[] Foto { get; set; }

        public VOCarnetInscripcion() { }

        public VOCarnetInscripcion(int numero, DateTime expedido, byte[] foto)
        {
            this.Numero = numero;
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

        public VOCarnetInscripcion(int numero, DateTime expedido)
        {
            this.Numero = numero;
            this.Expedido = expedido;
        }
    }
}