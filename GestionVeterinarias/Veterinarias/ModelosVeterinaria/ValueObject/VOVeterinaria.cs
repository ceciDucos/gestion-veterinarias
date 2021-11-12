using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOVeterinaria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<VOVeterinario> Veterinarios { get; set; }
        public List<VOCliente> Clientes { get; set; }
        public List<VOConsulta> Consultas { get; set; }

        public VOVeterinaria(){}

        public VOVeterinaria(int id, string nombre, string direccion, string telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Veterinarios = new List<VOVeterinario>();
            this.Clientes = new List<VOCliente>();
            this.Consultas = new List<VOConsulta>();
        }

        public VOVeterinaria(string nombre, string direccion, string telefono)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Veterinarios = new List<VOVeterinario>();
            this.Clientes = new List<VOCliente>();
            this.Consultas = new List<VOConsulta>();
        }
    }
}
