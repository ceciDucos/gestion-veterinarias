using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaVeterinarias.Classes
{
    class Veterinaria
    {
        private int id;
        public int Id { get { return id; }}
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Dictionary<Veterinario> DiccionarioVeterinarios { get; }
        public Dictionary<Cliente> DiccionarioClientes { get; }
        public Dictionary<Consulta> DiccionarioConsultas { get; }

        public Veterinaria() { }

        public Veterinaria(int id, string nombre, string direccion, string telefono)
        { 
            this.id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.DiccionarioVeterinarios = new Dictionary<int, Veterinario>();
            this.DiccionarioClientes = new Dictionary<int, Cliente>();
            this.DiccionarioConsultas = new Dictionary<int, Consulta>();
        }

        public void AddVeterinario(VOVeterinario vo)
        {
            Veterinario venterinario = new Veterinario(vo.GetCedula(), vo.GetNombre(), vo.GetTelefono, vo.GetHorario);
            this.DiccionarioVeterinarios.Add(vo.GetCedula(), venterinario);
        }

        public void AddCliente(VOCliente vo)
        {
            Cliente cliente = new Cliente(vo.GetCedula(), vo.GetNombre(), vo.GetTelefono, vo.GetDireccion, vo.GetCorreo(), 
                vo.getActivo(), vo.getDiccionarioMascotas());
            this.DiccionarioClientes.Add(vo.GetCedula(), cliente);
        }

        public void AddConsulta(VOConsulta vo)
        {
            Consulta consulta = new Consulta(vo.GetNumero(), vo.GetFecha(), vo.GetDescripcion(), vo.GetCalificacion(), vo.GetMascota()o);
            this.DiccionarioConsultas.Add(vo.GetNumero(), consulta);
        }

        public void RemoveVeterinario(int id)
        {
             this.DiccionarioVeterinarios.Remove(id);
        }

        public void RemoveCliente(int id)
        {
             this.DiccionarioCliente.Remove(id);
        }
    }
}