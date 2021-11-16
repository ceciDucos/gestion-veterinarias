﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.Classes
{
    public class Consulta
    {
        private int numero;

        public int Numero { get { return numero; } }
        public int Calificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Mascota Mascota { get; set; }
        public Veterinario Veterinario { get; set; }

        public Consulta(int calif, DateTime fecha, string desc, Mascota mascota, Veterinario veterinario)
        {
            this.Calificacion = calif;
            this.Fecha = fecha;
            this.Descripcion = desc;
            this.Mascota = mascota;
            this.Veterinario = veterinario;
        }

        public Consulta(int num, int calif, DateTime fecha, string desc, Mascota mascota, Veterinario veterinario)
        {
            this.numero = num;
            this.Calificacion = calif;
            this.Fecha = fecha;
            this.Descripcion = desc;
            this.Mascota = mascota;
            this.Veterinario = veterinario;
        }
    }
}
