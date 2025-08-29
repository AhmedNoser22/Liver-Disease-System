namespace Liver_Disease_System.DTOs
{
    public class CreateMedicalRecordDto
    {
        [Required(ErrorMessage = "Diagnosis is required.")]
        public string Diagnosis { get; set; } = default!;
        public IFormFile? DiagnosisImage { get; set; }
        [Required(ErrorMessage = "Liver stage is required.")]
        public string LiverStage { get; set; } = default!;
        public int PatientId { get; set; }
    }
}
