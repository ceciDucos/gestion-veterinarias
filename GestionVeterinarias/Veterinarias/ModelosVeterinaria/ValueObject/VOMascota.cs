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

        public VOMascota(int id, TipoAnimal animal, string nombre, Raza raza, int edad, bool vacunaAlDia)
        {
            this.id = id;
            this.Animal = animal;
            this.Nombre = nombre;
            this.Raza = raza;
            this.Edad = edad;
            this.VacunaAlDia = vacunaAlDia;
        }

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
