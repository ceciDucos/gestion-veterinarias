using System.Collections.Generic;

namespace ModelosVeterinarias.Classes
{
    public class Mascota
    {
        public int Id { get; }
        public TipoAnimal TipoAnimal { get; set; }
        public string Nombre { get; set; }
        public Raza Raza { get; set; }
        public int Edad { get; set; }
        public bool VacunasAlDia { get; set; }
        //public CarnetInscripcion CarnetInscripcion { get; set; }

        public Mascota() { }

        public Mascota(int id, TipoAnimal tipo, string nombre, Raza raza, int edad, bool vacunasAlDia)
        {
            this.Id = id;
            this.TipoAnimal = tipo;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunasAlDia = vacunasAlDia;
        }

        public Mascota(TipoAnimal tipo, string nombre, Raza raza, int edad, bool vacunasAlDia) 
        {
            this.TipoAnimal = tipo;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunasAlDia = vacunasAlDia;
        }

        /*public void AddCarnet(CarnetInscripcion carnet)
        {
            this.CarnetInscripcion = carnet;
        }

        public void RemoveCarnet(int numero)
        {
            this.CarnetInscripcion = null;
        }*/
    }
}
