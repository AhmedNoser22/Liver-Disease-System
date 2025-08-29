namespace Liver_Disease_System.DTOs
{
    public class PatientDto
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public string NationalId { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
