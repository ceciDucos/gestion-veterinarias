using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.Classes
{
    class Consulta
    {
        private int numero;

        public int Numero { get { return numero; } }
        public int Calificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Mascota Mascota { get; set; }

        public Consulta(int num, int calif, DateTime date, string desc, Mascota pet)
        {
            numero = num;
            Calificacion = calif;
            Fecha = date;
            Descripcion = desc;
            Mascota = pet;
        }
    }
}
