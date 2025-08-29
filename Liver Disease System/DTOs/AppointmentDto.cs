namespace Liver_Disease_System.DTOs
{
    public class AppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; } = default!;
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
