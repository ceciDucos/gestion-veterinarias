using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelosVeterinarias.Classes
{
    public class Veterinaria
    {
        private int id;
        public int Id { get { return id; } }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Dictionary<long, Veterinario> DiccionarioVeterinarios { get; }
        public Dictionary<long, Cliente> DiccionarioClientes { get; }
        public Dictionary<int, Consulta> DiccionarioConsultas { get; }

        public Veterinaria() { }

        public Veterinaria(string nombre, string direccion, string telefono)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.DiccionarioVeterinarios = new Dictionary<long, Veterinario>();
            this.DiccionarioClientes = new Dictionary<long, Cliente>();
            this.DiccionarioConsultas = new Dictionary<int, Consulta>();
        }

        public Veterinaria(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.DiccionarioVeterinarios = new Dictionary<long, Veterinario>();
            this.DiccionarioClientes = new Dictionary<long, Cliente>();
            this.DiccionarioConsultas = new Dictionary<int, Consulta>();
        }

        
    }
}
