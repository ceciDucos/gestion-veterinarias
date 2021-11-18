using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.Classes
{
    public class Consulta
    {
        private int numero;

        public int Numero { get { return numero; } }
        public int Calificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Mascota Mascota { get; set; }
        public Veterinario Veterinario { get; set; }
        public bool Realizada { get; set; }
        public double Importe{ get; set; }


        public Consulta(int calif, DateTime fecha, string desc, Mascota mascota, Veterinario veterinario, bool realizada, double importe)
        {
            this.Calificacion = calif;
            this.Fecha = fecha;
            this.Descripcion = desc;
            this.Mascota = mascota;
            this.Veterinario = veterinario;
            this.Realizada = realizada;
            this.Importe = importe;
        }

        public Consulta(int num, int calif, DateTime fecha, string desc, Mascota mascota, Veterinario veterinario, bool realizada, double importe)
        {
            this.numero = num;
            this.Calificacion = calif;
            this.Fecha = fecha;
            this.Descripcion = desc;
            this.Mascota = mascota;
            this.Veterinario = veterinario;
            this.Realizada = realizada;
            this.Importe = importe;
        }
    }
}
