namespace Domain.Entities
{
    public class Estudiante
    {
        public int id { get; set; }
        public string? cedula { get; set; }
        public string? primer_nombre { get; set; }
        public string? segundo_nombre { get; set; }
        public string? primer_apellido { get; set; }
        public string? segundo_apellido { get; set; }
        public string? ciudad { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
    }
}
