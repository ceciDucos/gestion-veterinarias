using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaVeterinarias.Classes
{
    class Veterinaria
    {
        public int Id { get; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Dictionary<long, Veterinario> DiccionarioVeterinarios { get; }
        public Dictionary<long, Cliente> DiccionarioClientes { get; }
        public Dictionary<int, Consulta> DiccionarioConsultas { get; }

        public Veterinaria() { }

        public Veterinaria(int id, string nombre, string direccion, string telefono)
        { 
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.DiccionarioVeterinarios = new Dictionary<long, Veterinario>();
            this.DiccionarioClientes = new Dictionary<long, Cliente>();
            this.DiccionarioConsultas = new Dictionary<int, Consulta>();
        }

        public void AddVeterinario(Veterinario veterinario)
        {
            this.DiccionarioVeterinarios.Add(veterinario.GetCedula(), venterinario);
        }

        public void AddCliente(Cliente cliente)
        {
            this.DiccionarioClientes.Add(cliente.GetCedula(), cliente);
        }

        public void AddConsulta(Consulta consulta)
        {
            this.DiccionarioConsultas.Add(consulta.GetNumero(), consulta);
        }

        public void RemoveVeterinario(long cedula)
        {
             this.DiccionarioVeterinarios.Remove(cedula);
        }

        public void RemoveCliente(long cedula)
        {
             this.DiccionarioCliente.Remove(cedula);
        }
    }
}
