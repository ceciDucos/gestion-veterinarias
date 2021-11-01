using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOMascota
    {
        public TipoAnimal Animal { get; }
        public string Nombre { get; }
        public Raza Raza { get; }
        public int Edad { get; }
        public bool VacunaAlDia { get; }

        public VOMascota(TipoAnimal animal, string nombre, Raza raza, int edad, bool vacunaAlDia)
        {
            this.Animal = animal;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunaAlDia = vacunaAlDia;
        }

    }
}
