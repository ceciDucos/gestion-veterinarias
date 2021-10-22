using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaVeterinarias.Classes
{
    class Mascota
    {
        private int id;
        public int Id { get { return id; }}
        public Animal TipoAnimal { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public bool VacunasAlDia { get; set; }
        public CarnetInscripcion CarnetInscripcion { get; set; }

        public Mascota() { }

        public Mascota(int id, Animal tipo, string raza, int edad, bool vacunasAlDia, CarnetInscripcion carnet) 
        {
            this.id = id;
            this.TipoAnimal = tipo;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunasAlDia = vacunasAlDia;
            this.CarnetInscripcion = carnet;
        }

    }
}
