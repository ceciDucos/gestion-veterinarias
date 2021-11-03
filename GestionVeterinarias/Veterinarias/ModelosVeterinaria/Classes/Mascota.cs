using System.Collections.Generic;

namespace ModelosVeterinarias.Classes
{
    public class Mascota
    {
        private int id;

        public int Id { get; }
        public TipoAnimal TipoAnimal { get; set; }
        public string Nombre { get; set; }
        public Raza Raza { get; set; }
        public int Edad { get; set; }
        public bool VacunasAlDia { get; set; }
        public Dictionary<int, CarnetInscripcion> DiccionarioCarnet { get; }

        public Mascota() { }

        public Mascota(int id, TipoAnimal tipo, string nombre, Raza raza, int edad, bool vacunasAlDia)
        {
            this.Id = id;
            this.TipoAnimal = tipo;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunasAlDia = vacunasAlDia;
            this.DiccionarioCarnet = new Dictionary<int, CarnetInscripcion>();
        }

        public Mascota(TipoAnimal tipo, string nombre, Raza raza, int edad, bool vacunasAlDia) 
        {
            this.TipoAnimal = tipo;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunasAlDia = vacunasAlDia;
            this.DiccionarioCarnet = new Dictionary<int, CarnetInscripcion>();
        }

        public void AddCarnet(CarnetInscripcion carnet)
        {
            this.DiccionarioCarnet.Add(carnet.Numero, carnet);
        }

        public void RemoveCarnet(int numero)
        {
            this.DiccionarioCarnet.Remove(numero);
        }
    }
}
