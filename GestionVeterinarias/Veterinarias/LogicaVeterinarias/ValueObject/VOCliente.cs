using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOCliente
    {
        public long Cedula { get; }
        public String Nombre { get; }
        public String Telefono { get; }
        public String Direccion { get; }
        public String Correo { get; }
        public String Clave { get; }
        public bool Activo { get; }
        public List<VOMascota> Mascotas { get; }


        public VOCliente(long Cedula, String Nombre, String Telefono, String Direccion, String Correo, String Clave, bool Activo)
        {
            this.Cedula = Cedula;
            this.Nombre = Nombre;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Correo = Correo;
            this.Clave = Clave;
            this.Activo = Activo;
            this.Mascotas = new List<VOMascota>();

        }

    }
}
