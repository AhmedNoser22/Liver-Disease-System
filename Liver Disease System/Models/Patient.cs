namespace Liver_Disease_System.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public string NationalId { get; set; } = default!;
        public string Address { get; set; } = default!;
        public MedicalRecord MedicalRecord { get; set; }=default!; //Composition
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<PatientMedicine> patientMedicines { get; set; } = new List<PatientMedicine>();
    }
}
