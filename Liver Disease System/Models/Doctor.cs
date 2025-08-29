namespace Liver_Disease_System.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Specialization { get; set; } = default!;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
