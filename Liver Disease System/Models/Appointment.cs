namespace Liver_Disease_System.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; } = default!;
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!; // Composition relationship with Patient
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!; // Composition relationship with Doctor
    }
}
