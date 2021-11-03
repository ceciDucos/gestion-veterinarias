using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOCarnetInscripcion
    {
<<<<<<< HEAD
        private int numero;

        public int Numero { get { return numero; } }
        public DateTime Expedido { get; }
        public byte[] Foto { get; }

        public VOCarnetInscripcion(int numero, DateTime expedido, byte[] foto)
=======
        private int num;
        public int Numero { get { return num; } }
        public DateTime Expedido { get; }
        public byte[] Foto { get; }

        public VOCarnetInscripcion(DateTime expedido, byte[] foto)
        {
            this.Expedido = expedido;
            this.Foto = foto;
        }
        public VOCarnetInscripcion(int num, DateTime expedido, byte[] foto)
>>>>>>> 5315b05... cosulta entero y edit cliente
        {
            this.numero = numero;
            this.Expedido = expedido;
            this.Foto = foto;
            this.num = num;
        }

        public VOCarnetInscripcion(DateTime expedido, byte[] foto)
        {
            this.Expedido = expedido;
            this.Foto = foto;
        }
    }
}