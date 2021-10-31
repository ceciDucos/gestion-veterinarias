using System;
using LogicaVeterinarias.Controller;
using LogicaVeterinarias.ValueObject;

namespace ConsolaVeterinarias
{
    class Program
    {
        static void Main(string[] args)
        {
            FachadaWin fachadaWin = new FachadaWin();
            fachadaWin.CrearCliente(new VOCliente(12345678, "doble de pepe", "093345543", "ya sabes", "pepe@gmail.com", "pass", true));

            //public VOCliente(long cedula, string nombre, string telefono, string direccion, string correo, string clave, bool activo)
        }
    }
}
