﻿using LogicaVeterinarias.Controller;
using ModelosVeterinarias.ValueObject;
using ModelosVeterinarias.Classes;
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

            // ================== INICIO CECI PRUEBAS ==================
            /*
            fachadaWin.CrearCliente(new VOCliente(90909077, "Ceci2", "099000999", "addressceci", "ceci@gmail.com", "pass", true));
            fachadaWin.EliminarCliente(90909077);
             */
            // ================== FIN CECI PRUEBAS ==================


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
            Console.ReadLine();
            */
            // ================== FIN RODRIGO PRUEBAS ==================

            // ================== INICIO GONZALO PRUEBAS ==================
            /*
            fachadaWin.CrearMascota(new VOMascota(TipoAnimal.Perro, "Bichofeo", Raza.Policia, 4, true));
            fachadaWin.CrearMascota(new VOMascota(TipoAnimal.Perro, "Moncho", Raza.Policia, 2, true));
            fachadaWin.EliminarMascota(2);
            fachadaWin.EditarMascota(new VOMascota(1, TipoAnimal.Perro, "Firulais2", Raza.Policia, 2, true));
            if (fachadaWin.MemberMascota(2))
                Console.WriteLine("existe");
            else
                Console.WriteLine("no existe");
            Console.ReadLine();
            */
            // ================== FIN GONZALO PRUEBAS ==================

        }
    }
}
