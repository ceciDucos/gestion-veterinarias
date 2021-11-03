using LogicaVeterinarias.Controller;
using ModelosVeterinarias.ValueObject;
using System;
using System.Drawing;
using System.IO;

namespace ConsolaVeterinarias
{
    class Program
    {
        static void Main(string[] args)
        {
            FachadaWin fachadaWin = new FachadaWin();
            //Pruebas Ceci

<<<<<<< HEAD
            // ================== INICIO FEDE PRUEBAS ==================

            //fachadaWin.CrearVeterianaria(new VOVeterinaria("Los gatitos", "nenecho", "091234567"));
            //fachadaWin.EditarVeterianaria(new VOVeterinaria(1, "Los gatitos3", "nenecho3", "091234563"));
            //fachadaWin.EliminarVeterianaria(3);
            //Image img = Image.FromFile(@"C:\Users\fedep\OneDrive\Imágenes\Fondos\DelPiero.jpg"); // cambiar direccion de la foto a una de su propia pc
            //byte[] arr;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    arr = ms.ToArray();
            //}
            //fachadaWin.CrearCarnet(arr);

            //Image img2 = Image.FromFile(@"C:\Users\fedep\OneDrive\Imágenes\Prueba.jpg"); // cambiar direccion de la foto a una de su propia pc
            //byte[] arr2;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    img2.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    arr2 = ms.ToArray();
            //}
            //fachadaWin.EditarCarnet(new VOCarnetInscripcion(10000, DateTime.Now, arr2));
            //Console.ReadLine();

           // ================== FIN FEDE PRUEBAS ==================

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
=======
            //fachadaWin.CrearCliente(new VOCliente(11111789, "CeciNuevo", "099000999", "addressceci", "ceci@gmail.com", "pass", true));
            //fachadaWin.EditarCliente(new VOCliente(11111789, "testingEdit", "123123123", "editAdress", "edit@gmail.com", "1234pass", false));
            //fachadaWin.EliminarCliente(11111789);

            //byte[] foto = null;
            //VOMascota voMascota = new VOMascota(999, TipoAnimal.Perro, "Larry", Raza.Golden, 4, true, new VOCarnetInscripcion(new DateTime(), foto));
            //DateTime date = DateTime.Today;
            //fachadaWin.CrearConsulta(new VOConsulta(0, date, "algo", 10, voMascota));
            //fachadaWin.EliminarConsulta(1);
            //fachadaWin.EditarConsulta(new VOConsulta(1, date, "yuyuyuyuyu", 9, voMascota));
 
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
>>>>>>> 5315b05... cosulta entero y edit cliente
             Console.ReadLine();

            // ================== FIN RODRIGO PRUEBAS ==================
        }
    }
}
