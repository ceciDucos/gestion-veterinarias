using LogicaVeterinarias.Controller;
using LogicaVeterinarias.ValueObject;
using System;

namespace ConsolaVeterinarias
{
    class Program
    {
        static void Main(string[] args)
        {
            FachadaWin fachadaWin = new FachadaWin();
            fachadaWin.CrearCliente(new VOCliente(12345678, "Pepe", "093345543", "address1", "pepe@gmail.com", "pass", true));
            Console.ReadLine();
            //public VOCliente(long cedula, string nombre, string telefono, string direccion, string correo, string clave, bool activo)
        }
    }
}
