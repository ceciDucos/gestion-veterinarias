using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaVeterinarias.ValueObject
{
    class VOMascota
    {
        public int Id { get;}
        public TipoAnimal Animal { get;}
        public String  Nombre { get; }
        public Raza Raza{ get;}
        public int Edad { get;}
        public bool VacunaAlDia { get;}
        public Dictionary<VOMascota> Mascotas{ get; }

        public VOMascota(int Id, TipoAnimal Animal, String Nombre, Raza Raza, int Edad, bool VacunaAlDia, )
        {
            this.Id = Id;
            this.Animal = Animal;
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.VacunaAlDia = VacunaAlDia;
            this.Mascotas = new Dictionary<VOMascota>;
        
        }

    }
}
