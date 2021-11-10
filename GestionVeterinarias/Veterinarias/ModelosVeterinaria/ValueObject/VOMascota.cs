namespace ModelosVeterinarias.ValueObject
{
    public class VOMascota
    {
        private int id;

        public int Id { get { return id; } }
        public long cedulaCliente { get; }
        public TipoAnimal Animal { get; }
        public string Nombre { get; }
        public Raza Raza { get; }
        public int Edad { get; }
        public bool VacunaAlDia { get; }
        public VOCarnetInscripcion CarnetInscripcion { get; }

        public VOMascota() { }

        public VOMascota(int id, long cedulaCliente, TipoAnimal animal, string nombre, Raza raza, int edad, bool vacunaAlDia, VOCarnetInscripcion carnet)
        {
            this.id = id;
            this.cedulaCliente = cedulaCliente;
            this.Animal = animal;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunaAlDia = vacunaAlDia;
            this.CarnetInscripcion = carnet;
        }

        public VOMascota(long cedulaCliente, TipoAnimal animal, string nombre, Raza raza, int edad, bool vacunaAlDia, VOCarnetInscripcion carnet)
        {
            this.cedulaCliente = cedulaCliente;
            this.Animal = animal;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunaAlDia = vacunaAlDia;
            this.CarnetInscripcion = carnet;
        }

    }
}
