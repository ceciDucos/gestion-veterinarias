using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOCliente
    {
        public long Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int IdVeterinaria { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public List<VOMascota> Mascotas { get; set; }

        public VOCliente() { }

        public VOCliente(long cedula, string nombre, string telefono, int idVeterinaria, string direccion, string correo, string pass, bool activo)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.IdVeterinaria = idVeterinaria;
            this.Direccion = direccion;
            this.Correo = correo;
            this.Clave = pass;
            this.Activo = activo;
            this.Mascotas = new List<VOMascota>();
        }

        public VOCliente(long cedula, string nombre, string telefono, int idVeterinaria, string direccion, string correo, string pass, bool activo, List<VOMascota> mascotas)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.IdVeterinaria = idVeterinaria;
            this.Direccion = direccion;
            this.Correo = correo;
            this.Clave = pass;
            this.Activo = activo;
            this.Mascotas = mascotas;
        }

    }
}
