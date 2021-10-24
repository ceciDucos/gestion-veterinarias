using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOConsulta
    {

        public DateTime Fecha{ get;}
        public String  Descripcion { get; }
        public int Calificacion { get;}
        public VOMascota Mascota { get;}

        

        public VOConsulta(DateTime Fecha, String Descripcion, int Calificacion, VOMascota Mascota)
        {
            this.Fecha = Fecha;
            this.Descripcion = Descripcion;
            this.Calificacion = Calificacion;
            this.Mascota = Mascota
        
        }

    }
}
