using LogicaVeterinarias.Controller;
using ModelosVeterinarias.ValueObject;
using System;

namespace ConsolaVeterinarias
{
    class Program
    {
        static void Main(string[] args)
        {
            FachadaWin fachadaWin = new FachadaWin();
            fachadaWin.CrearCliente(new VOCliente(90909077, "Ceci2", "099000999", "addressceci", "ceci@gmail.com", "pass", true));
            //fachadaWin.EliminarCliente(90909077);

             // ================== INICIO RODRIGO PRUEBAS ==================
            /* 
            try{
                fachadaWin.CrearVeterinario(new VOVeterinario(123456, "Juan", "12345", "88888"));
                fachadaWin.CrearVeterinario(new VOVeterinario(5678, "Pepito", "12345", "88888"));
                fachadaWin.EliminarVeterinario(123456);
                VOVeterinario vo_para_editar = new VOVeterinario(5678, "qqqq", "5555", "Lunes a Dom de 10a21");
                fachadaWin.EditarVeterinario(vo_para_editar);
                Console.WriteLine("Ejecutada con exito");
             }
             catch (Exception e)
             {
                Console.WriteLine("Error: {0} ", e.Message);
                
             }
            */
             Console.ReadLine();

            // ================== FIN RODRIGO PRUEBAS ==================
        }
    }
}
