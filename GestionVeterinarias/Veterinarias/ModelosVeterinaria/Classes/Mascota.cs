using System.Collections.Generic;

namespace ModelosVeterinarias.Classes
{
    public class Mascota
    {
        public int Id { get; }
        public long CedulaCliente { get; set; }
        public TipoAnimal TipoAnimal { get; set; }
        public string Nombre { get; set; }
        public Raza Raza { get; set; }
        public int Edad { get; set; }
        public bool VacunasAlDia { get; set; }
        public CarnetInscripcion CarnetInscripcion { get; set; }

        public Mascota() { }

        public Mascota(int id, long cedulaCliente, TipoAnimal tipo, string nombre, Raza raza, int edad, bool vacunasAlDia, CarnetInscripcion carnet)
        {
            this.Id = id;
            this.CedulaCliente = cedulaCliente;
            this.TipoAnimal = tipo;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunasAlDia = vacunasAlDia;
            this.CarnetInscripcion = carnet;
        }

        public Mascota(long cedulaCliente, TipoAnimal tipo, string nombre, Raza raza, int edad, bool vacunasAlDia, CarnetInscripcion carnet)
        {
            this.CedulaCliente = cedulaCliente;
            this.TipoAnimal = tipo;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunasAlDia = vacunasAlDia;
            this.CarnetInscripcion = carnet;
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
