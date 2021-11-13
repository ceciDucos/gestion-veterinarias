namespace ModelosVeterinarias.ValueObject
{
    public class VOMascota
    {
        private int id;

        public int Id { get { return id; } }
        public long cedulaCliente { get; set; }
        public TipoAnimal Animal { get; set; }
        public string Nombre { get; set; }
        public Raza Raza { get; set; }
        public int Edad { get; set; }
        public bool VacunaAlDia { get; set; }
        public VOCarnetInscripcion CarnetInscripcion { get; set; }

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
