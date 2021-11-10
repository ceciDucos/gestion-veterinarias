using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOCliente
    {
        public long Cedula { get; }
        public string Nombre { get; }
        public string Telefono { get; }
        public string Direccion { get; }
        public string Correo { get; }
        public string Clave { get; }
        public bool Activo { get; }
        public List<VOMascota> Mascotas { get; }

        public VOCliente() { }

        public VOCliente(long cedula, string nombre, string telefono, string direccion, string correo, string clave, bool activo)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Correo = correo;
            this.Clave = clave;
            this.Activo = activo;
            this.Mascotas = new List<VOMascota>();
        }

    }
}
