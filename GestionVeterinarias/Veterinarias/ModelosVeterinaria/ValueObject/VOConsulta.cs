using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOConsulta
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Calificacion { get; set; }
        public VOMascota Mascota { get; set; }

        public VOVeterinario Veterinario { get; set; }

        public VOConsulta() { }



        public VOConsulta(DateTime fecha, string descripcion, int calificacion, VOMascota mascota, VOVeterinario veterinario)
        {
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.Calificacion = calificacion;
            this.Mascota = mascota;
            this.Veterinario = veterinario;
        }

        public VOConsulta(int numero, DateTime fecha, string descripcion, int calificacion, VOMascota mascota, VOVeterinario veterinario)
        {
            this.Numero = numero;
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.Calificacion = calificacion;
            this.Mascota = mascota;
            this.Veterinario = veterinario;
        }

    }
}
