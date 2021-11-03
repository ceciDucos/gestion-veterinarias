using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelosVeterinarias.ValueObject;

namespace ModelosVeterinarias.ValueObject
{
    public class VOMascota
    {
        private int id;
        public int Id { get { return id; } }
        public TipoAnimal Animal { get; }
        public string Nombre { get; }
        public Raza Raza { get; }
        public int Edad { get; }
        public bool VacunaAlDia { get; }
        public VOCarnetInscripcion CarnetInscipcion { get; }

        public VOMascota(TipoAnimal animal, string nombre, Raza raza, int edad, bool vacunaAlDia, VOCarnetInscripcion carnet)
        {
            this.Animal = animal;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunaAlDia = vacunaAlDia;
            this.CarnetInscipcion = carnet;
        }

        public VOMascota(int id, TipoAnimal animal, string nombre, Raza raza, int edad, bool vacunaAlDia, VOCarnetInscripcion carnet)
        {
            this.Animal = animal;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunaAlDia = vacunaAlDia;
            this.CarnetInscipcion = carnet;
            this.id = id;
        }

    }
}
