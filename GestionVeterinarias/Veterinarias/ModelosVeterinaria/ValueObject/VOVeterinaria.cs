using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOVeterinaria
    {
        public int Id { get; }
        public string Nombre { get; }
        public string Direccion { get; }
        public string Telefono { get; }
        public List<VOVeterinario> Veterinarios { get; }
        public List<VOCliente> Clientes { get; }
        public List<VOConsulta> Consultas { get; }

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
