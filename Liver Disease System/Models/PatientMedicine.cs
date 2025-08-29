namespace Liver_Disease_System.Models
{
    public class PatientMedicine
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!; // Composition relationship with Patient
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = default!; // Composition relationship with Medicine
        public string Duration { get; set; } = default!;

    }
}
