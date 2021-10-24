using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOVeterinaria
    {
        public String  Nombre { get; }
        public String  Direccion { get; }
        public String  Telefono { get; }
        public Dictionary<VOVeterinario> Veterinarios{ get; }
        public Dictionary<VOCliente> Clientes{ get; }
        public Dictionary<VOConsulta> Consultas{ get; }



        public VOVeterinaria(String Nombre, String Direccion, String Telefono)
        {
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Veterinarios = new Dictionary<VOVeterinario>;
            this.Clientes = new Dictionary<VOCliente>;
            this.Consultas = new Dictionary<VOConsulta>;

        
        }

    }
}
