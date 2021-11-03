using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelosVeterinarias.Classes
{
    public class Mascota
    {
        public int Id { get; }
        public TipoAnimal TipoAnimal { get; set; }
        public Raza Raza { get; set; }
        public int Edad { get; set; }
        public bool VacunasAlDia { get; set; }
        public CarnetInscripcion CarnetInscripcion { get; set; }
        public Mascota() { }

        public Mascota(int id, TipoAnimal tipo, Raza raza, int edad, bool vacunasAlDia, CarnetInscripcion carnet) 
        {
            this.TipoAnimal = tipo;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunasAlDia = vacunasAlDia;
            this.CarnetInscripcion = carnet;
            this.Id = id;
        }

    }
}
