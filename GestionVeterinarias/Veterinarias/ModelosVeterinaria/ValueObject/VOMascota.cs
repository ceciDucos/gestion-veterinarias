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
        public VOCarnetInscripcion CarnetInscripcion { get; }

        public VOMascota(int id, TipoAnimal animal, string nombre, Raza raza, int edad, bool vacunaAlDia, VOCarnetInscripcion carnet)
        {
            this.id = id;
            this.Animal = animal;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunaAlDia = vacunaAlDia;
            this.CarnetInscripcion = carnet;
        }

        public VOMascota(TipoAnimal animal, string nombre, Raza raza, int edad, bool vacunaAlDia, VOCarnetInscripcion carnet)
        {
            this.Animal = animal;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunaAlDia = vacunaAlDia;
            this.CarnetInscripcion = carnet;
        }

    }
}
