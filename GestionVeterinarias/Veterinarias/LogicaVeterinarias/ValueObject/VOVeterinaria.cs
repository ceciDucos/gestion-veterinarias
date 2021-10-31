using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    public class VOVeterinaria
    {
        public string Nombre { get; }
        public string Direccion { get; }
        public string Telefono { get; }
        public Dictionary<long, VOVeterinario> Veterinarios { get; }
        public Dictionary<long, VOCliente> Clientes { get; }
        public Dictionary<int, VOConsulta> Consultas { get; }
        public VOVeterinaria(string nombre, string direccion, string telefono)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Veterinarios = new Dictionary<long, VOVeterinario>();
            this.Clientes = new Dictionary<long, VOCliente>();
            this.Consultas = new Dictionary<int, VOConsulta>();
        }

    }
}
