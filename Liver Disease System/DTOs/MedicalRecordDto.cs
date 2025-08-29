namespace Liver_Disease_System.DTOs
{
    public class MedicalRecordDto
    {
        public string Diagnosis { get; set; } = default!;
        public byte[]? DiagnosisImage { get; set; }
        public string LiverStage { get; set; } = default!;
        public int PatientId { get; set; }
    }
}
