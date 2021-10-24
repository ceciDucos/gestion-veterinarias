using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOConsulta
    {
        public DateTime Fecha { get; }
        public string Descripcion { get; }
        public int Calificacion { get; }
        public VOMascota Mascota { get; }
        public VOConsulta(DateTime fecha, string descripcion, int calificacion, VOMascota mascota)
        {
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.Calificacion = calificacion;
            this.Mascota = mascota;
        }

    }
}
