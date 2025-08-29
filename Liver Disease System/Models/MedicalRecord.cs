namespace Liver_Disease_System.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; } = default!;
        public byte[]? DiagnosisImage { get; set; }
        public string LiverStage { get; set; } = default!;
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!; // Composition relationship with Patient
    }
}
